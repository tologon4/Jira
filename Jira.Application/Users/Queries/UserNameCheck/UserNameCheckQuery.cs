using MediatR;

namespace Jira.Application.Users.Queries.UserNameCheck;

public class UserNameCheckQuery : IRequest<bool>
{
    /// <summary>
    /// User's UserName 
    /// </summary>
    public string UserName { get; set; }
}