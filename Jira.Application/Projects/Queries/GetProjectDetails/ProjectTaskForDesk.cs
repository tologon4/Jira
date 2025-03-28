using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Domain;
using Jira.Domain.Enums;

namespace Jira.Application.Projects.Queries.GetProjectDetails;

public class ProjectTaskForDesk : IMapWith<ProjectTask>
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
    /// Task's number
    /// </summary>
    public string TaskNumber { get; set; }
    
    /// <summary>
    /// UserAuthor ID who created task
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// UserExecutor ID who execute task
    /// </summary>
    public int ExecutorId { get; set; }
    
    /// <summary>
    /// User Executor who execute task
    /// </summary>
    public virtual User Executor { get; set; }
    
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
        profile.CreateMap<ProjectTask, ProjectTaskForDesk>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(vm => vm.Title, opt => opt.MapFrom(p => p.Title))
            .ForMember(vm => vm.Priority, opt => opt.MapFrom(p => p.Priority))
            .ForMember(vm => vm.TaskNumber, opt => opt.MapFrom(p => p.TaskNumber))
            .ForMember(vm => vm.Executor, opt => opt.MapFrom(p => p.Executor))
            .ForMember(vm => vm.Status, opt => opt.MapFrom(p => p.Status))
            .ForMember(vm => vm.Type, opt => opt.MapFrom(p => p.Type))
            .ForMember(vm => vm.ExecutorId, opt => opt.MapFrom(p => p.ExecutorId))
            .ForMember(vm => vm.AuthorId, opt => opt.MapFrom(p => p.AuthorId));
    }
}