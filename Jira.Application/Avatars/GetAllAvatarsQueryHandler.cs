using AutoMapper;
using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Avatars;

public class GetAllAvatarsQueryHandler : IRequestHandler<GetAllAvatarsQuery, Result<List<Avatar>>>
{
    private readonly IJiraDbContext _dbContext;

    public GetAllAvatarsQueryHandler(IJiraDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Result<List<Avatar>>> Handle(GetAllAvatarsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Avatars.ToListAsync(cancellationToken);
    }
}