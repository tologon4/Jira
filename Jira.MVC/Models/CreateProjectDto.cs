using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Domain.Enums;

namespace Jira.MVC.Models;

public class CreateProjectDto : IMapWith<CreateProjectCommand>
{
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
    /// ProjectManager ID of Project
    /// </summary>
    public int? ProjectManagerId { get; set; }
    
    /// <summary>
    /// Users IDs which can take part of Project
    /// </summary>
    public ICollection<int>? EmployeeIds { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
            .ForMember(dest => dest.CompanyCustomerName, opt => opt.MapFrom(src => src.CompanyCustomerName))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.ProjectManagerId, opt => opt.MapFrom(src => src.ProjectManagerId))
            .ForMember(dest => dest.CompanyExecutorName, opt => opt.MapFrom(src => src.CompanyExecutorName))
            .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.EmployeeIds));

    }
}