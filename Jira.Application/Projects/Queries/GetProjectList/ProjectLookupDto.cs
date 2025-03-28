using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Domain;
using Jira.Domain.Enums;

namespace Jira.Application.Projects.Queries.GetProjectList;

public class ProjectLookupDto : IMapWith<Project>
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
    /// Project's Type
    /// </summary>
    public ProjectType ProjectType { get; set; }
    
    /// <summary>
    /// ProjectManager's name of Project
    /// </summary>
    public string ProjectManagerName { get; set; }
    
    /// <summary>
    /// Name of Customer Company that requests this project
    /// </summary>
    public string CompanyCustomerName { get; set; }
    
    /// <summary>
    /// Project's Priority
    /// </summary>
    public Priority Priority { get; set; }
    
    /// <summary>
    /// Project's avatar url
    /// </summary>
    public string AvatarUrl { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectLookupDto>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(vm => vm.ProjectName, opt => opt.MapFrom(p => p.ProjectName))
            .ForMember(vm => vm.KeyName, opt => opt.MapFrom(p => p.KeyName))
            .ForMember(vm => vm.CompanyCustomerName, opt => opt.MapFrom(p => p.CompanyCustomerName))
            .ForMember(vm => vm.Priority, opt => opt.MapFrom(p => p.Priority))
            .ForMember(vm => vm.ProjectType, opt => opt.MapFrom(p => p.ProjectType))
            .ForMember(vm => vm.ProjectManagerName, opt => opt.MapFrom(p => $"{p.ProjectManager.LastName} {p.ProjectManager.FirstName}"))
            .ForMember(vm => vm.AvatarUrl, opt => opt.MapFrom(p => p.AvatarUrl));
    }
}