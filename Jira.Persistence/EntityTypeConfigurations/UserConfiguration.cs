using Jira.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jira.Persistance.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany<Project>(u => u.CreatedProjects);
        builder.HasMany<Project>(u => u.EmployeeProjects);
        builder.HasMany<Project>(u => u.ManageProjects);
        builder.HasMany<ProjectTask>(u => u.ProjectTasks);
    }
}