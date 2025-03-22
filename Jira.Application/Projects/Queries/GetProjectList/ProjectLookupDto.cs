using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Domain;

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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectLookupDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(p => p.Id))
            .ForMember(dto => dto.ProjectName, opt => opt.MapFrom(p => p.ProjectName));
    }
}