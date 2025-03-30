using FluentResults;
using MediatR;

namespace Jira.Application.ProjectTasks.Commands.DeletePrjectTask;

public class DeleteProjectTaskCommand : IRequest<Result<string>>
{
    public DeleteProjectTaskCommand(int taskId, int userId)
    {
        Id = taskId;
        UserId = userId;
    }
    /// <summary>
    /// Task's Identification Number
    /// </summary>
    public int Id { get; set; } 
    
    /// <summary>
    /// User's ID
    /// </summary>
    public int UserId { get; set; }
}