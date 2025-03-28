using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Jira.Application.Users.Commands.Login;
using Jira.Application.Users.Commands.SignIn;

namespace Jira.MVC.Models;
/// <summary>
/// user login view model
/// </summary>
public class LoginVm
{
    /// <summary>
    /// User's login(userName, email)
    /// </summary>
    [Required(ErrorMessage = "Please provide a field!")]
    public string Login { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    [Required(ErrorMessage = "Please provide a Password!")]
    public string Password { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoginVm, LoginCommand>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }
}