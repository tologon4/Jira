using FluentResults;
using Jira.Domain;
using MediatR;

namespace Jira.Application.Users.Commands.Login;

public class LoginCommand : IRequest<Result<User>>
{
    /// <summary>
    /// User's login(userName, email)
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// User's Password
    /// </summary>
    public string Password { get; set; }
}