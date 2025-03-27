using FluentResults;
using Jira.Application.Common.Exceptions;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Commands.UpdateProject;

public class UpdateProjectCommandHandler(IJiraDbContext dbContext) : IRequestHandler<UpdateProjectCommand, Result<string>>
{
    /// <summary>
    /// Project updating command handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Result of operation</returns>
    public async Task<Result<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var oldProject = await dbContext.Projects
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (oldProject == null || oldProject.Id != request.Id)
            return Result.Fail($"Project with ID {request.Id} was not found!");
        if (oldProject.CreatorId != request.UserId || oldProject.ProjectManagerId != request.UserId)
            return Result.Fail($"You cannot update the project with ID {request.Id}!");
        
        var newEmployees = new List<User>();
        if (request.EmployeeIds != null || request.EmployeeIds.Count > 0)
        {
            newEmployees = await dbContext.Users
                .Where(u => request.EmployeeIds.Contains(u.Id))
                .ToListAsync(cancellationToken);
        }

        oldProject.ProjectName = request.ProjectName;
        oldProject.KeyName = request.KeyName;
        oldProject.CompanyCustomerName = request.CompanyCustomerName;
        oldProject.CompanyExecutorName = request.CompanyExecutorName;
        oldProject.Priority = request.Priority;
        oldProject.EndDate = request.EndDate;
        oldProject.ProjectManagerId = request.ProjectManagerId;
        oldProject.Employees = newEmployees;
        oldProject.ProjectType = request.ProjectType;
        
        dbContext.Projects.Update(oldProject);
        var result = await dbContext.SaveChangesAsync(cancellationToken);
        if (result <= 0) 
            return Result.Fail("Updating of project failed!");
        return Result.Ok("Project was updated successfully!");
    }
}