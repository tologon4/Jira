using MediatR;

namespace Jira.Application.Users.Queries.UserNameCheck;

public class UserNameCheckQuery : IRequest<bool>
{
    public UserNameCheckQuery(string userName, int? id)
    {
        UserName = userName;
        Id = id;
    }
    /// <summary>
    /// User's UserName 
    /// </summary>
    public string UserName { get; set; }
    
    public int? Id { get; set; }
}