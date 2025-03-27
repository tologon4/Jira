using MediatR;

namespace Jira.Application.Users.Queries;

public class EmailCheckQuery : IRequest<bool>
{
    /// <summary>
    /// User's Email Address 
    /// </summary>
    public string Email { get; set; }
}