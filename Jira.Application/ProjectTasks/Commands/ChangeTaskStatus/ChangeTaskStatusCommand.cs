using FluentResults;
using Jira.Domain.Enums;
using MediatR;

namespace Jira.Application.ProjectTasks.Commands.ChangeStatus;

public class ChangeTaskStatusCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Task's Identification Number
    /// </summary>
    public int TaskId { get; set; }
    
    /// <summary>
    /// Task's Status
    /// </summary>
    public ProjectTaskStatus Status { get; set; }
}