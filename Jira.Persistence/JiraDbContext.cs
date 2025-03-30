using Jira.Application.Interfaces;
using Jira.Domain;
using Jira.Persistance.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jira.Persistance;
public class JiraDbContext : IdentityDbContext<User, IdentityRole<int>, int>, IJiraDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<Avatar> Avatars { get; set; }

    public JiraDbContext(DbContextOptions<JiraDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProjectConfiguration());
        builder.ApplyConfiguration(new ProjectTaskConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(builder);
    }
}