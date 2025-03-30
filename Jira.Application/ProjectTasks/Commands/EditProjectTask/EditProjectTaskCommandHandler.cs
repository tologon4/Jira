using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.ProjectTasks.Commands.EditProjectTask;

public class EditProjectTaskCommandHandler(IJiraDbContext dbContext) : IRequestHandler<EditProjectTaskCommand, Result<string>>
{
    /// <summary>
    /// Project Task creation command handler
    /// </summary>
    /// <param name="request">Project Task creation data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    public async Task<Result<string>> Handle(EditProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var oldTask = await dbContext.ProjectTasks
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (oldTask == null)
            return Result.Fail("Task not found!");
        oldTask.Title = request.Title;
        oldTask.Description = request.Description;
        oldTask.Priority = request.Priority;
        if(request.ExecutorId != null)
            oldTask.ExecutorId = (int)request.ExecutorId;
        oldTask.Status = request.Status;
        oldTask.Type = request.Type;
        
        dbContext.ProjectTasks.Update(oldTask);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        
        if (result <= 0) 
            Result.Fail("Editing of task failed!");
        
        return Result.Ok("Task updated successfully!");
    }
}