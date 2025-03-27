using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Users.Queries;

public class EmailCheckQueryHandler(IJiraDbContext dbContext) : IRequestHandler<EmailCheckQuery, bool>
{
    public async Task<bool> Handle(EmailCheckQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Users.AnyAsync(u => u.Email == request.Email, cancellationToken: cancellationToken);
    }
}