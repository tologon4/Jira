using FluentResults;
using Jira.Domain.Enums;
using MediatR;

namespace Jira.Application.ProjectTasks.Commands.EditProjectTask;

public class EditProjectTaskCommand : IRequest<Result<string>>
{
    /// <summary>
    /// Task's Identification Number
    /// </summary>
    public int Id { get; set; } 
    
    /// <summary>
    /// Task's Title (name)
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Current User Id
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Task's Description (comment)
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// UserExecutor ID who execute task
    /// </summary>
    public int? ExecutorId { get; set; }
    
    /// <summary>
    /// Task's Status
    /// </summary>
    public ProjectTaskStatus Status { get; set; }
    
    /// <summary>
    /// Task's Priority
    /// </summary>
    public Priority Priority { get; set; }
    
    /// <summary>
    /// Task's Type
    /// </summary>
    public ProjectTaskType Type { get; set; }
    
    /// <summary>
    /// Project's ID, where task is in
    /// </summary>
    public int ProjectId { get; set; }
}