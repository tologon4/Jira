using FluentResults;
using Jira.Domain.Enums;
using MediatR;
namespace Jira.Application.Projects.Commands.CreateProject;
public class CreateProjectCommand : IRequest<Result<int>>
{
    /// <summary>
    /// CreatorUser's ID who created project
    /// </summary>
    public int CreatorId { get; set; }
    
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
    public string CompanyExecutorName { get; set; }
    
    /// <summary>
    /// Project's Started Date
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// Project's End Date
    /// </summary>
    public DateTime EndDate { get; set; }
    
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
    /// Users IDs which can take part of Project
    /// </summary>
    public ICollection<int>? EmployeeIds { get; set; }
}