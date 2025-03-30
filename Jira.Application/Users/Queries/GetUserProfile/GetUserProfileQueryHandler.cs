using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Users.Queries.GetUserProfile;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, Result<UserProfile>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public GetUserProfileQueryHandler(IJiraDbContext dbContext, UserManager<User> userManager, IMapper mapper)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Get user profile data
    /// </summary>
    /// <param name="request">get user data</param>
    /// <param name="cancellationToken">Cancellation token</param>
    public async Task<Result<UserProfile>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .ProjectTo<UserProfile>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            return Result.Fail("user not found");
        return Result.Ok(user);
    }
}