using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Queries.GetProjectListForProjectCreate;

public class GetUsersListForProjectCreateQuery : IRequest<Result<List<UserForProjectCreateVm>>>
{
    
}