using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectDetails;

public class GetProjectDetailsQuery : IRequest<Result<ProjectDetailsVm>>
{
    public GetProjectDetailsQuery(int projectId, int userId)
    {
        Id = projectId;
        UserId = userId;
    }
    /// <summary>
    /// Project's Identification Number
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Updating User ID
    /// </summary>
    public int UserId { get; set; }
}