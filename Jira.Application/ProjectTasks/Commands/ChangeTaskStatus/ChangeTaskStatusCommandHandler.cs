using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.ProjectTasks.Commands.ChangeStatus;

public class ChangeTaskStatusCommandHandler(IJiraDbContext dbContext) : IRequestHandler<ChangeTaskStatusCommand, Result<string>>
{
    
    /// <summary>
    /// Project task's status changing
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    public async Task<Result<string>> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.ProjectTasks
            .FirstOrDefaultAsync(t => t.Id == request.TaskId, cancellationToken);
        task.Status = request.Status;
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok("Project task status updated");
    }
}