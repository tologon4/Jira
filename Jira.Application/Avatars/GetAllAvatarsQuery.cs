using FluentResults;
using Jira.Domain;
using MediatR;

namespace Jira.Application.Avatars;

public class GetAllAvatarsQuery : IRequest<Result<List<Avatar>>>
{
    
}