using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.Projects.Queries.GetProjectDetails;
using Jira.Domain;
using Jira.Domain.Enums;

namespace Jira.Application.Projects.Queries.GetProjectForUpdate;

public class ProjectForUpdateVm : IMapWith<Project>
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
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectForUpdateVm>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(vm => vm.ProjectName, opt => opt.MapFrom(p => p.ProjectName))
            .ForMember(vm => vm.KeyName, opt => opt.MapFrom(p => p.KeyName))
            .ForMember(vm => vm.CompanyCustomerName, opt => opt.MapFrom(p => p.CompanyCustomerName))
            .ForMember(vm => vm.CompanyExecutorName, opt => opt.MapFrom(p => p.CompanyExecutorName))
            .ForMember(vm => vm.StartDate, opt => opt.MapFrom(p => p.StartDate))
            .ForMember(vm => vm.EndDate, opt => opt.MapFrom(p => p.EndDate))
            .ForMember(vm => vm.Priority, opt => opt.MapFrom(p => p.Priority))
            .ForMember(vm => vm.ProjectType, opt => opt.MapFrom(p => p.ProjectType))
            .ForMember(vm => vm.EmployeeIds, opt => opt.MapFrom(p => p.Employees.Select(u => u.Id)));
    }
}