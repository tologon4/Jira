using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Users.Queries.UserNameCheck;

public class UserNameCheckQueryHandler(IJiraDbContext dbContext) : IRequestHandler<UserNameCheckQuery, bool>
{
    public async Task<bool> Handle(UserNameCheckQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .AnyAsync(u => (u.UserName == request.UserName && request.Id == null) 
                           && !(u.UserName == request.UserName && u.Id == request.Id), cancellationToken: cancellationToken);
    }
}