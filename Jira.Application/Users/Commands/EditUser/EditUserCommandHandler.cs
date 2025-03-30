using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Users.Commands.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Result<string>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly UserManager<User> _userManager;

    public EditUserCommandHandler(IJiraDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    
    /// <summary>
    /// Edit user profile
    /// </summary>
    /// <param name="request">user profile data</param>
    /// <param name="cancellationToken">cancellation token</param>
    public async Task<Result<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var oldUser = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        if(oldUser == null)
            return Result.Fail("User not found");
        
        oldUser.Email = request.Email;
        oldUser.FirstName = request.FirstName;
        oldUser.LastName = request.LastName;
        oldUser.UserName = request.UserName;
        oldUser.MiddleName = request.MiddleName;
        if (request.AvatarId != null)
        {
            var avatar = await _dbContext.Avatars
                .FirstOrDefaultAsync(a => a.Id == request.AvatarId, cancellationToken);
            oldUser.AvatarUrl = avatar?.Url;
        }

        await _userManager.UpdateAsync(oldUser);
        return Result.Ok("User updated");
    }
}