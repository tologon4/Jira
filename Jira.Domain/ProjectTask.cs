using Jira.Domain.Enums;

namespace Jira.Domain;

public class ProjectTask
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
    /// Task's Description (comment)
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// UserAuthor ID who created task
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// User Author who created task
    /// </summary>
    public virtual User Author { get; set; }
    
    /// <summary>
    /// UserExecutor ID who execute task
    /// </summary>
    public int ExecutorId { get; set; }
    
    /// <summary>
    /// User Executor who execute task
    /// </summary>
    public virtual User Executor { get; set; }
    
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
    public int PriorityId { get; set; }
    
    /// <summary>
    /// Project, where task is in
    /// </summary>
    public virtual Project Project { get; set; }
}