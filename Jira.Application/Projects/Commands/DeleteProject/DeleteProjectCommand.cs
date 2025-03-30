using FluentResults;
using MediatR;

namespace Jira.Application.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<Result<string>>
{
    public DeleteProjectCommand(int projectId)
    {
        Id = projectId;
    }
    /// <summary>
    /// Project's Identification Number
    /// </summary>
    public int Id { get; set; }
}