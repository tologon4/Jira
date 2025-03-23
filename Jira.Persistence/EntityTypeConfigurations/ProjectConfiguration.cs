using Jira.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jira.Persistance.EntityTypeConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasMany<User>(p => p.Employees);
        builder.HasOne<User>(p => p.ProjectManager);
        builder.HasOne<User>(p => p.Creator);
    }
}