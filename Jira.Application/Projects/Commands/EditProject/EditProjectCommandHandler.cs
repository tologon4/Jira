using FluentResults;
using Jira.Application.Common.Exceptions;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Commands.UpdateProject;

public class EditProjectCommandHandler(IJiraDbContext dbContext) : IRequestHandler<EditProjectCommand, Result<string>>
{
    /// <summary>
    /// Project updating command handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Result of operation</returns>
    public async Task<Result<string>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
    {
        var oldProject = await dbContext.Projects
            .Include(p => p.Employees)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (oldProject == null || oldProject.Id != request.Id)
            return Result.Fail($"Project with ID {request.Id} was not found!");
        
        var newEmployees = new List<User>();
        if (request.EmployeeIds != null || request.EmployeeIds.Count > 0)
        {
            newEmployees = await dbContext.Users
                .Where(u => request.EmployeeIds.Contains(u.Id))
                .ToListAsync(cancellationToken);
            oldProject.Employees?.Clear();
            oldProject.Employees = newEmployees;
        }

        oldProject.ProjectName = request.ProjectName;
        oldProject.KeyName = request.KeyName;
        oldProject.CompanyCustomerName = request.CompanyCustomerName;
        oldProject.CompanyExecutorName = request.CompanyExecutorName;
        oldProject.Priority = request.Priority;
        oldProject.EndDate = request.EndDate;
        oldProject.EditedTime = DateTime.Now;
        oldProject.ProjectManagerId = request.ProjectManagerId;
        oldProject.ProjectType = request.ProjectType;
        if (request.AvatarId != null)
        {
            var avatar = await dbContext.Avatars
                .FirstOrDefaultAsync(a => a.Id == request.AvatarId, cancellationToken: cancellationToken);
            oldProject.AvatarUrl = avatar.Url;
        }
        
        dbContext.Projects.Update(oldProject);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        if (result <= 0) 
            return Result.Fail("Updating of project failed!");
        return Result.Ok("Project was updated successfully!");
    }
}