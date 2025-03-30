using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.Projects.Commands.UpdateProject;
using Jira.Application.Projects.Queries.GetProjectForUpdate;
using Jira.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Models;

public class EditProjectDto : IMapWith<ProjectForUpdateVm>
{
    /// <summary>
    /// Project's Identification Number
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Project's Name
    /// </summary>
    [Required(ErrorMessage = "Please provide a Project name!")]
    public string ProjectName { get; set; }
    
    /// <summary>
    /// Project's KeyName
    /// </summary>
    [Required(ErrorMessage = "Please provide a Key name!")]
    public string KeyName { get; set; }
    
    /// <summary>
    /// Name of Customer Company that requests this project
    /// </summary>
    [Required(ErrorMessage = "Please provide a CompanyCustomer name!")]
    public string CompanyCustomerName { get; set; }
    
    /// <summary>
    /// Name of Executor Company that execut this project
    /// </summary>
    [Required(ErrorMessage = "Please provide a CompanyExecutor name!")]
    public string CompanyExecutorName { get; set; }
    
    /// <summary>
    /// Project's Started Date
    /// </summary>
    [Required(ErrorMessage = "Please provide a StartDate!")]
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// Project's End Date
    /// </summary>
    [Required(ErrorMessage = "Please provide an EndDate!")]
    [Remote("DatesValid", "Validation", ErrorMessage = "EndDate must be later than StartDate!", AdditionalFields = nameof(StartDate))]
    public DateTime EndDate { get; set; }
    
    /// <summary>
    /// Project's Priority
    /// </summary>
    [Required(ErrorMessage = "Please select a Priority!")]
    public Priority Priority { get; set; }
    
    /// <summary>
    /// Project's Type
    /// </summary>
    [Required(ErrorMessage = "Please select a ProjectType!")]
    public ProjectType ProjectType { get; set; }
    
    /// <summary>
    /// ProjectManager ID of Project
    /// </summary>
    [Required(ErrorMessage = "Please select a ProjectManager!")]
    public int ProjectManagerId { get; set; }
    
    /// <summary>
    /// Users IDs which can take part of Project
    /// </summary>
    public ICollection<int>? EmployeeIds { get; set; }
    
    public int? AvatarId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectForUpdateVm, EditProjectDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
            .ForMember(dest => dest.KeyName, opt => opt.MapFrom(src => src.KeyName))
            .ForMember(dest => dest.CompanyCustomerName, opt => opt.MapFrom(src => src.CompanyCustomerName))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.ProjectManagerId, opt => opt.MapFrom(src => src.ProjectManagerId))
            .ForMember(dest => dest.CompanyExecutorName, opt => opt.MapFrom(src => src.CompanyExecutorName))
            .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.EmployeeIds));
        
        profile.CreateMap<EditProjectDto, EditProjectCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName))
            .ForMember(dest => dest.KeyName, opt => opt.MapFrom(src => src.KeyName))
            .ForMember(dest => dest.CompanyCustomerName, opt => opt.MapFrom(src => src.CompanyCustomerName))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.ProjectManagerId, opt => opt.MapFrom(src => src.ProjectManagerId))
            .ForMember(dest => dest.CompanyExecutorName, opt => opt.MapFrom(src => src.CompanyExecutorName))
            .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.EmployeeIds))
            .ForMember(dest => dest.AvatarId, opt => opt.MapFrom(src => src.AvatarId));
    }
}