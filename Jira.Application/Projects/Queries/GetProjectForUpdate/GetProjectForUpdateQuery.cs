using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectForUpdate;

public class GetProjectForUpdateQuery : IRequest<Result<ProjectForUpdateVm>>
{
    public GetProjectForUpdateQuery(int id)
    {
        Id = id;
    }
    /// <summary>
    /// Project's Identification Number
    /// </summary>
    public int Id { get; set; }
}