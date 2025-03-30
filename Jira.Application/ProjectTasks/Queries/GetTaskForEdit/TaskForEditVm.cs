using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.ProjectTasks.Commands.EditProjectTask;
using Jira.Domain;
using Jira.Domain.Enums;

namespace Jira.Application.ProjectTasks.Queries.GetTaskForEdit;

public class TaskForEditVm : IMapWith<ProjectTask>
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
    /// UserExecutor ID who execute task
    /// </summary>
    public int ExecutorId { get; set; }
    
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
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProjectTask, TaskForEditVm>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ExecutorId, opt => opt.MapFrom(src => src.ExecutorId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
}