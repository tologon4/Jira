using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Queries.GetProjectListForProjectCreate;

public class GetUsersListForProjectCreateQueryHandler : IRequestHandler<GetUsersListForProjectCreateQuery, Result<List<UserForProjectCreateVm>>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUsersListForProjectCreateQueryHandler(IJiraDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Get user's list for Project Creating query handler
    /// </summary>
    /// <param name="request">data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>List of user's data</returns>
    public async Task<Result<List<UserForProjectCreateVm>>> Handle(GetUsersListForProjectCreateQuery request, CancellationToken cancellationToken)
    {
        var users = new List<UserForProjectCreateVm>();
        if(request.ProjectId != null)
            users = await _dbContext.Projects
                .Where(u => u.Id == request.ProjectId)
                .SelectMany(u => u.Employees)
                .ProjectTo<UserForProjectCreateVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        else
            users = await _dbContext.Users
                .ProjectTo<UserForProjectCreateVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        
        return Result.Ok(users);
    }
}