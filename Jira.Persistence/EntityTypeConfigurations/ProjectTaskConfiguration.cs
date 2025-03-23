using Jira.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jira.Persistance.EntityTypeConfigurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.HasOne<Project>(t => t.Project);
        builder.HasOne<User>(t => t.Author);
        builder.HasOne<User>(t => t.Executor);
    }
}