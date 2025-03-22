using Microsoft.EntityFrameworkCore;
using Jira.Application.Interfaces;
using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Commands.DeleteProject;

public class DeleteProjectHandler(IJiraDbContext dbContext) : IRequestHandler<DeleteProjectCommand, Result<string>>
{
    
    /// <summary>
    /// Project deleting command handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Result of operation</returns>
    public async Task<Result<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (project == null || project.Id != request.Id)
            return Result.Fail("Project was not found!");
        dbContext.Projects.Remove(project);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        if (result <= 0)
            return Result.Fail("Deletion of project failed!");
        return Result.Ok("Project deleted successfully!");
    }
}