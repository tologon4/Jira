using AutoMapper;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Queries.GetProjectDetails;

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, Result<ProjectDetailsVm>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProjectDetailsQueryHandler(IJiraDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    /// <summary>
    /// Get project details query handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Project data</returns>
    public async Task<Result<ProjectDetailsVm>> Handle(GetProjectDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects
            .Include(p => p.ProjectTasks)
                .ThenInclude(t => t.Executor)
            .Include(p => p.ProjectManager)
            .Include(p => p.Creator)
            .FirstOrDefaultAsync(p => p.Id == request.Id 
                && (p.CreatorId == request.UserId 
                || p.ProjectManagerId == request.UserId
                || p.Employees.Select(u => u.Id).Contains(request.UserId)), cancellationToken);
        if(project == null)
            return Result.Fail("Project not found");
        return Result.Ok(_mapper.Map<ProjectDetailsVm>(project));
    }

}