using AutoMapper;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Queries.GetProjectDetails;

public class GetProjectDetailsQueryHandler : IRequest<Result<ProjectDetailsVm>>
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
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (project == null || project.Id != request.Id)
            return Result.Fail("Project was not found!");
        if (project.CreatorId != request.UserId
            || project.ProjectManagerId != request.UserId || !project.Employees.Any(u => u.Id == request.UserId))
            return Result.Fail("You do not have access to this project!");
        return Result.Ok(_mapper.Map<ProjectDetailsVm>(project));
    }

}