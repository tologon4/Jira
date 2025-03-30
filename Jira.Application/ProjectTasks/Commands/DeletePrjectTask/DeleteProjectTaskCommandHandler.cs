using FluentResults;
using Jira.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.ProjectTasks.Commands.DeletePrjectTask;

public class DeleteProjectTaskCommandHandler(IJiraDbContext dbContext) : IRequestHandler<DeleteProjectTaskCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dbContext.ProjectTasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (task == null)
            return Result.Fail("Task not found");
        dbContext.ProjectTasks.Remove(task);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Result.Ok("Project task deleted");
    }
}