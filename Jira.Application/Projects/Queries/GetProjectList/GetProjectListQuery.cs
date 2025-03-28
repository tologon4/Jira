using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectList;

public class GetProjectListQuery : IRequest<Result<ProjectListVm>>
{
    /// <summary>
    /// UserId
    /// </summary>
    public int UserId { get; set; }
}