namespace Jira.Application.Projects.Queries.GetProjectList;

public class ProjectListVm
{
    /// <summary>
    /// List of projects
    /// </summary>
    public ICollection<ProjectLookupDto> Projects { get; set; }
}