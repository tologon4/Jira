using FluentResults;
using MediatR;

namespace Jira.Application.Users.Queries.GetUserProfile;

public class GetUserProfileQuery : IRequest<Result<UserProfile>>
{
    public GetUserProfileQuery(int userId)
    {
        Id = userId;
    }
    
    /// <summary>
    /// User's ID
    /// </summary>
    public int Id { get; set; }
}