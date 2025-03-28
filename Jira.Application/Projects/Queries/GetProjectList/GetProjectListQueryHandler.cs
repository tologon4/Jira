using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Queries.GetProjectList;

public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, Result<ProjectListVm>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProjectListQueryHandler(IJiraDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Get project list query handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>List of Project data</returns>
    public async Task<Result<ProjectListVm>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
    {
        var projects = await _dbContext.Projects
            .Where(p => p.CreatorId == request.UserId 
            || p.ProjectManagerId == request.UserId
            || p.Employees.Select(u => u.Id).Contains(request.UserId))
            .ProjectTo<ProjectLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return Result.Ok(new ProjectListVm(){Projects = projects});
    }
}