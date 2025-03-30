using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectListForProjectCreate;

public class GetUsersListForProjectCreateQuery : IRequest<Result<List<UserForProjectCreateVm>>>
{
    public GetUsersListForProjectCreateQuery(int? projectId)
    {
        ProjectId = projectId;
    }
    
    public int? ProjectId { get; set; }
}