using AutoMapper;
using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.ProjectTasks.Queries.GetTaskForEdit;

public class GetTaskForEditQueryHandler : IRequestHandler<GetTaskForEditQuery, Result<TaskForEditVm>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTaskForEditQueryHandler(IJiraDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Get task data for edit
    /// </summary>
    /// <param name="request">Task id</param>
    /// <param name="cancellationToken"></param>
    public async Task<Result<TaskForEditVm>> Handle(GetTaskForEditQuery request, CancellationToken cancellationToken)
    {
         var task = await _dbContext.ProjectTasks
             .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
         if(task == null)
             return Result.Fail("Task not found");
         return Result.Ok(_mapper.Map<TaskForEditVm>(task));
    }
    
}