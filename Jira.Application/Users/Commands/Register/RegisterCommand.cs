using FluentResults;
using Jira.Domain;
using MediatR;

namespace Jira.Application.Users.Commands.SignIn;

public class RegisterCommand : IRequest<Result<User>>
{
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
    /// User's User Name
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    /// URL for user's profile avatar
    /// </summary>
    public int? AvatarId { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    public string Password { get; set; }
}