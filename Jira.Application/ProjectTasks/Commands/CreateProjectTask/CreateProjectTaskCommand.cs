using FluentResults;
using Jira.Domain.Enums;
using MediatR;

namespace Jira.Application.ProjectTasks.Commands.CreateProjectTask;

public class CreateProjectTaskCommand : IRequest<Result<int>>
{
    /// <summary>
    /// Task's Title (name)
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Task's Description (comment)
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// UserAuthor ID who created task
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// UserExecutor ID who execute task
    /// </summary>
    public int ExecutorId { get; set; }
    
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