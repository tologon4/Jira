using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Jira.Application.Common.Mappings;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.Users.Commands.SignIn;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Models;
/// <summary>
/// User sign in view model
/// </summary>
public class RegisterVm : IMapWith<RegisterCommand>
{
    /// <summary>
    /// User's Family Name
    /// </summary>
    [Required(ErrorMessage = "Please provide a LastName!")]
    public string LastName { get; set; }
    
    /// <summary>
    /// User's Name
    /// </summary>
    [Required(ErrorMessage = "Please provide a FirstName!")]
    public string FirstName { get; set; }
    
    /// <summary>
    /// User's Middle Name
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// User's Email Address 
    /// </summary>
    [Required(ErrorMessage = "Please provide a Email!")]
    [Remote("EmailValid", "Validation", ErrorMessage = "Email is already in use!")]
    public string Email { get; set; }
    
    /// <summary>
    /// User's User Name
    /// </summary>
    [Required(ErrorMessage = "Please provide a UserName!")]
    [Remote("UserNameValid", "Validation", ErrorMessage = "UserName is already in use!")]
    public string UserName { get; set; }
    
    /// <summary>
    /// URL for user's profile avatar
    /// </summary>
    public int? AvatarId { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please provide a Password!")]
    public string Password { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please provide a Confirm Password!")]
    [Compare("Password", ErrorMessage = "Confirm Password is invalid! Try again")]
    public string ConfirmPassword { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterVm, RegisterCommand>()
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.AvatarId, opt => opt.MapFrom(src => src.AvatarId));
    }
}