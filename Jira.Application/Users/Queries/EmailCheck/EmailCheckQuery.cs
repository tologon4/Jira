using MediatR;

namespace Jira.Application.Users.Queries;

public class EmailCheckQuery : IRequest<bool>
{
    public EmailCheckQuery(string email, int? id)
    {
        Email = email;
        Id = id;
    }
    /// <summary>
    /// User's Email Address 
    /// </summary>
    public string Email { get; set; }
    
    public int? Id { get; set; }
}