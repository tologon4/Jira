using Jira.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Interfaces;

public interface IJiraDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<ProjectTask> ProjectTasks { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}