using Jira.Domain.Enums;

namespace Jira.Domain;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string CompanyCustomerName { get; set; }
    public string CompanyExecutorName {get; set;}
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectPriority Priority { get; set; }
}