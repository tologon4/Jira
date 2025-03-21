using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Projects.Commands.CreateProject;

public class CreateProjectCommandHandler(IJiraDbContext context) : IRequestHandler<CreateProjectCommand, Result<int>>
{
    /// <summary>
    /// Project creating command handler
    /// </summary>
    /// <param name="request">Project data</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Project's ID</returns>
    public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var employees = new List<User>();
        
        if (request.EmployeeIds != null || request.EmployeeIds.Count > 0)
        {
            employees = await context.Users
                .Where(u => request.EmployeeIds.Contains(u.Id))
                .ToListAsync(cancellationToken);
        }
        
        var project = new Project()
        {
            ProjectName = request.ProjectName,
            CompanyCustomerName = request.CompanyCustomerName,
            CompanyExecutorName = request.CompanyExecutorName,
            Priority = request.Priority,
            ProjectManagerId = request.ProjectManagerId,
            CreatorId = request.CreatorId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Employees = employees
        };
        
        await context.Projects.AddAsync(project, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);
        if (result <= 0) 
            Result.Fail("Creation of project failed!");
        
        return Result.Ok(project.Id);
    }
}