using AutoMapper;
using Jira.Application.ProjectTasks.Commands.EditProjectTask;
using Jira.Application.ProjectTasks.Queries.GetTaskForEdit;

namespace Jira.MVC.Models.ProjectTaskModels;

public class EditProjectTaskDto
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
    public int? ExecutorId { get; set; }
    
    /// <summary>
    /// Task's Status
    /// </summary>
    public int Status { get; set; }
    
    /// <summary>
    /// Task's Priority
    /// </summary>
    public int Priority { get; set; }
    
    /// <summary>
    /// Task's Type
    /// </summary>
    public int Type { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TaskForEditVm, EditProjectTaskDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ExecutorId, opt => opt.MapFrom(src => src.ExecutorId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        
        profile.CreateMap<EditProjectTaskDto, EditProjectTaskCommand>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ExecutorId, opt => opt.MapFrom(src => src.ExecutorId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
}