using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.Projects.Queries.GetProjectList;
using Jira.Domain;

namespace Jira.Application.Projects.Queries.GetProjectListForProjectCreate;

public class UserForProjectCreateVm : IMapWith<User>
{
    /// <summary>
    /// User's Identification Number
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// User's FullName - LastName + FirstName
    /// </summary>
    public string FullName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserForProjectCreateVm>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(vm => vm.FullName, opt => opt.MapFrom(u => $"{u.LastName} {u.FirstName}"));
    }
}