using FluentResults;
using MediatR;

namespace Jira.Application.Users.Commands.EditUser;

public class EditUserCommand : IRequest<Result<string>>
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
    public int? AvatarId { get; set; }
}