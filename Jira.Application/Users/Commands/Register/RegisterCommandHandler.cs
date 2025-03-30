using FluentResults;
using Jira.Application.Interfaces;
using Jira.Application.Users.Commands.SignIn;
using Jira.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jira.Application.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<User>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    
    public RegisterCommandHandler(IJiraDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }
    
    /// <summary>
    /// Registration
    /// </summary>
    /// <param name="request">Registration user data</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    public async Task<Result<User>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        var avatar = await _dbContext.Avatars
            .FirstOrDefaultAsync(a => a.Id == (request.AvatarId ?? rnd.Next(1, 13)), cancellationToken: cancellationToken);
        User user = new User()
        {
            LastName = request.LastName,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            Email = request.Email,
            UserName = request.UserName,
            AvatarUrl = avatar.Url
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "employee");
            return Result.Ok(user);
        }
        else
            return Result.Fail($"{string.Join("\n", result.Errors)}");
    }
}