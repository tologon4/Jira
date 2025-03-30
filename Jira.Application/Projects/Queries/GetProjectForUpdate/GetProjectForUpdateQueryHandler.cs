using AutoMapper;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Queries.GetProjectForUpdate;

public class GetProjectForUpdateQueryHandler : IRequestHandler<GetProjectForUpdateQuery, Result<ProjectForUpdateVm>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetProjectForUpdateQueryHandler(IJiraDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    /// <summary>
    /// get Project details for edit
    /// </summary>
    /// <param name="request">project id </param>
    /// <param name="cancellationToken">Cancellation tolen</param>
    public async Task<Result<ProjectForUpdateVm>> Handle(GetProjectForUpdateQuery request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Employees)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (project == null)
            return Result.Fail("Project not found");
        return Result.Ok(_mapper.Map<ProjectForUpdateVm>(project));
    }
}