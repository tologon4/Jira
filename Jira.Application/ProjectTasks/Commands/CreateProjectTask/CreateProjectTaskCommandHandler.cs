using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using Jira.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.ProjectTasks.Commands.CreateProjectTask;

public class CreateProjectTaskCommandHandler(IJiraDbContext dbContext) : IRequestHandler<CreateProjectTaskCommand, Result<int>>
{
    
    /// <summary>
    /// Project Task creation command handler
    /// </summary>
    /// <param name="request">Project Task creation data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    public async Task<Result<int>> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .FirstOrDefaultAsync(p => p.Id == request.ProjectId, cancellationToken);
        var taskNum = $"{project.KeyName}-{(project.ProjectTasks == null ? 0 : project.ProjectTasks.Count) + 1}";
        var task = new ProjectTask()
        {
            Title = request.Title,
            TaskNumber = taskNum,
            Description = request.Description,
            Priority = request.Priority,
            AuthorId = request.AuthorId,
            ExecutorId = request.ExecutorId,
            ProjectId = request.ProjectId,
            Status = ProjectTaskStatus.Opened,
            Type = request.Type
        };
        await dbContext.ProjectTasks.AddAsync(task, cancellationToken);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        if (result <= 0) 
            Result.Fail("Creation of task failed!");
        
        return Result.Ok(task.Id);
    }
}