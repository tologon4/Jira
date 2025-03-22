using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectList;

public class GetProjectListQuery : IRequest<Result<ProjectListVm>>
{
    /// <summary>
    /// ProjectManager ID of Project
    /// </summary>
    public int? ProjectManagerId { get; set; }
    
    /// <summary>
    /// CreatorUser's ID who created project
    /// </summary>
    public int? CreatorId { get; set; }
    
    /// <summary>
    /// User which take part of Project
    /// </summary>
    public int? EmployeeId { get; set; }
}