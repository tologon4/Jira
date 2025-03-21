using Jira.Domain;
using Jira.Persistance.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jira.Persistance;
public class JiraDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    DbSet<User> Users { get; set; }
    DbSet<Project> Projects { get; set; }

    public JiraDbContext(DbContextOptions<JiraDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProjectConfiguration());
        base.OnModelCreating(builder);
    }
}