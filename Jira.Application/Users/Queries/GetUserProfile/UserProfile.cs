using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Domain;

namespace Jira.Application.Users.Queries.GetUserProfile;

public class UserProfile : IMapWith<Profile>
{
    /// <summary>
    /// User's ID
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// User's username
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// User's Family Name
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// User's Name
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// User's Middle Name
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// User's Email Address 
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// URL for user's profile avatar
    /// </summary>
    public string? AvatarUrl { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserProfile>()
            .ForMember(vm => vm.Id, opt => opt.MapFrom(u => u.Id))
            .ForMember(vm => vm.UserName, opt => opt.MapFrom(u => u.UserName))
            .ForMember(vm => vm.LastName, opt => opt.MapFrom(u => u.LastName))
            .ForMember(vm => vm.FirstName, opt => opt.MapFrom(u => u.FirstName))
            .ForMember(vm => vm.MiddleName, opt => opt.MapFrom(u => u.MiddleName))
            .ForMember(vm => vm.Email, opt => opt.MapFrom(u => u.Email))
            .ForMember(vm => vm.AvatarUrl, opt => opt.MapFrom(u => u.AvatarUrl));
    }
}