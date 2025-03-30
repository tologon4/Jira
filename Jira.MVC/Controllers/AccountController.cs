using AutoMapper;
using Jira.Application.Avatars;
using Jira.Application.Users.Commands.EditUser;
using Jira.Application.Users.Commands.Login;
using Jira.Application.Users.Commands.SignIn;
using Jira.Application.Users.Queries.GetUserProfile;
using Jira.Domain;
using Jira.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;
/// <summary>
/// Controller for working with user
/// </summary>
public class AccountController : BaseController
{
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;

    public AccountController(IMapper mapper, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _signInManager = signInManager;
    }

    /// <summary>
    /// User's profile page
    /// </summary>
    /// <param name="userId">User ID</param>
    [HttpGet]
    public async Task<ActionResult> Profile(int? userId)
    {
        var user = Mediator.Send(new GetUserProfileQuery(userId ?? UserId)).Result.Value;
        return View(user);
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int? userId)
    {
        ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
        var user = Mediator.Send(new GetUserProfileQuery(userId ?? UserId)).Result.Value;
        return View(_mapper.Map<EditUserVm>(user));
    }

    /// <summary>
    /// Edit user profile
    /// </summary>
    /// <param name="data">User profile data</param>
    [HttpPost]
    public async Task<ActionResult> Edit(EditUserVm data)
    {
        if (!ModelState.IsValid) return View(data);
        var command = _mapper.Map<EditUserCommand>(data);
        var result = await Mediator.Send(command);
        if (result.IsFailed)
        {
            ModelState.AddModelError(string.Empty, result.Errors.First().ToString() ?? string.Empty);
            return View(data);
        }
        return RedirectToAction("Profile", "Account", new { userId = result.Value });
    }
    
    /// <summary>
    /// Login page
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    /// <summary>
    /// Login 
    /// </summary>
    /// <param name="data">User login data</param>
    [HttpPost]
    public async Task<IActionResult> Login(LoginVm data)
    {
        if (!ModelState.IsValid) return View(data);
        var command = _mapper.Map<LoginCommand>(data);
        var result = await Mediator.Send(command);
        if (result.IsFailed)
        {
            ModelState.AddModelError(string.Empty, result.Errors.First().ToString() ?? string.Empty);
            return View(data);
        }
        await _signInManager.SignInAsync(result.Value, false);
        return RedirectToAction("Index", "Project");
    }
    
    /// <summary>
    /// Registration page
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Register()
    {
        ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
        return View();
    }
    
    /// <summary>
    /// Registration
    /// </summary>
    /// <param name="data">User registration data</param>
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm data)
    {
        if (!ModelState.IsValid) return View(data);
        var command = _mapper.Map<RegisterCommand>(data);
        var result = await Mediator.Send(command);
        if (result.IsFailed)
        {
            ModelState.AddModelError(string.Empty, result.Errors.First().ToString() ?? string.Empty);
            return View(data);
        }
        await _signInManager.SignInAsync(result.Value, false);
        return RedirectToAction("Index", "Project");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}