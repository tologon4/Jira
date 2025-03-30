using FluentResults;
using Jira.Application.Interfaces;
using Jira.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Jira.Application.Users.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<User>>
{
    private readonly IJiraDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    
    public LoginCommandHandler(IJiraDbContext dbContext, UserManager<User> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="request">Login</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    public async Task<Result<User>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByEmailAsync(request.Login);
        if (user == null)
            user = await _userManager.FindByNameAsync(request.Login);
        if (user == null) 
            return Result.Fail($"Login or password is incorrect.");
        return Result.Ok(user);
    }
}