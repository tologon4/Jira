using Jira.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jira.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<JiraDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<IJiraDbContext>(provider => provider.GetRequiredService<JiraDbContext>());
        return services;
    }
}