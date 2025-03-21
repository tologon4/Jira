using Jira.Domain.Enums;

namespace Jira.Domain;
/// <summary>
/// Project
/// </summary>
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
    /// Project's Priority
    /// </summary>
    public Priority Priority { get; set; }
}