using System.ComponentModel;
using Jira.Domain.Enums;

namespace Jira.Domain;
/// <summary>
/// Project
/// </summary>
[Description("Project")]
public class Project
{
    /// <summary>
    /// Project's Identification Number
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Project's Name
    /// </summary>
    public string ProjectName { get; set; }
    
    /// <summary>
    /// Project's KeyName
    /// </summary>
    public string KeyName { get; set; }

    /// <summary>
    /// Name of Customer Company that requests this project
    /// </summary>
    public string CompanyCustomerName { get; set; }
    
    /// <summary>
    /// Name of Executor Company that execut this project
    /// </summary>
    public string CompanyExecutorName {get; set;}
    
    /// <summary>
    /// Project's Started Date
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// Project's End Date
    /// </summary>
    public DateTime EndDate { get; set; }
    
    /// <summary>
    /// Project's Edited time
    /// </summary>
    public DateTime EditedTime { get; set; }
    
    /// <summary>
    /// Project's Priority
    /// </summary>
    public Priority Priority { get; set; }
    
    /// <summary>
    /// Project's Type
    /// </summary>
    public ProjectType ProjectType { get; set; }
    
    /// <summary>
    /// ProjectManager ID of Project
    /// </summary>
    public int ProjectManagerId { get; set; }
    
    /// <summary>
    /// ProjectManager of Project
    /// </summary>
    public virtual User? ProjectManager { get; set; }
    
    /// <summary>
    /// Users which can take part of Project
    /// </summary>
    public virtual ICollection<User>? Employees { get; set; }
    
    /// <summary>
    /// CreatorUser's ID who created project
    /// </summary>
    public int CreatorId { get; set; }
    
    /// <summary>
    /// CreatorUser who created project
    /// </summary>
    public virtual User? Creator { get; set; }
}