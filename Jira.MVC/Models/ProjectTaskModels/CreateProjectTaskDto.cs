using AutoMapper;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.ProjectTasks.Commands.CreateProjectTask;
using Jira.Domain.Enums;

namespace Jira.MVC.Models.ProjectTaskModels;

public class CreateProjectTaskDto
{
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
    /// Task's Priority
    /// </summary>
    public int Priority { get; set; }
    
    /// <summary>
    /// Task's Type
    /// </summary>
    public int Type { get; set; }
    
    /// <summary>
    /// Project's ID, where task is in
    /// </summary>
    public int ProjectId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProjectTaskDto, CreateProjectTaskCommand>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ExecutorId, opt => opt.MapFrom(src => src.ExecutorId))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));
    }
}