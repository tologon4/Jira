using System.Reflection;
using Jira.Application;
using Jira.Application.Interfaces;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.Projects.Commands.UpdateProject;
using Jira.Application.Projects.Queries.GetProjectForUpdate;
using Jira.Application.ProjectTasks.Commands.CreateProjectTask;
using Jira.Application.ProjectTasks.Commands.EditProjectTask;
using Jira.Application.ProjectTasks.Queries.GetTaskForEdit;
using Jira.Application.Users.Commands.EditUser;
using Jira.Application.Users.Commands.Login;
using Jira.Application.Users.Commands.SignIn;
using Jira.Application.Users.Queries.GetUserProfile;
using Jira.Domain;
using Jira.MVC.Models;
using Jira.MVC.Models.ProjectTaskModels;
using Jira.Persistance;
using Jira.Persistance.DbInitializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(
    Assembly.GetExecutingAssembly(),
    typeof(IJiraDbContext).Assembly
);

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddControllers();
builder.Services.AddDbContext<JiraDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DBConnection"), 
        x => x.MigrationsAssembly("Jira.Persistence")))
    .AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireDigit = true;
    }).AddEntityFrameworkStores<JiraDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<RegisterVm, RegisterCommand>();
    cfg.CreateMap<CreateProjectDto, CreateProjectCommand>();
    cfg.CreateMap<LoginVm, LoginCommand>();
    cfg.CreateMap<CreateProjectTaskDto, CreateProjectTaskCommand>();
    cfg.CreateMap<ProjectForUpdateVm, EditProjectDto>();
    cfg.CreateMap<EditProjectDto, EditProjectCommand>();
    cfg.CreateMap<TaskForEditVm, EditProjectTaskDto>();
    cfg.CreateMap<EditProjectTaskDto, EditProjectTaskCommand>();
    cfg.CreateMap<UserProfile, EditUserVm>();
    cfg.CreateMap<EditUserVm, EditUserCommand>();
    
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var context = serviceProvider.GetRequiredService<JiraDbContext>();
        DbInitializer.Initialize(context);
        await RolesInitializer.InitializeAsync(roleManager);
        await AdminsInitializer.Initialize(userManager);
        await AvatarsInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database initialization error: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    var request = context.HttpContext.Request;

    if (response.StatusCode == 403 || response.StatusCode == 401 || response.StatusCode == 404)
    {
        var referer = request.Headers["Referer"].ToString();
        if (!string.IsNullOrEmpty(referer)) response.Redirect(referer);
        else response.Redirect("/");
    }
    await Task.CompletedTask;
});

app.UseAuthentication();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Project}/{action=Index}/{id?}");

app.Run();