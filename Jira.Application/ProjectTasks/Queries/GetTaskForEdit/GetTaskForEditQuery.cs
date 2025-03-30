using FluentResults;
using MediatR;

namespace Jira.Application.ProjectTasks.Queries.GetTaskForEdit;

public class GetTaskForEditQuery : IRequest<Result<TaskForEditVm>>
{
    public GetTaskForEditQuery(int projectId)
    {
        Id = projectId;
    }
    /// <summary>
    /// Task's Identification Number
    /// </summary>
    public int Id { get; set; } 
}