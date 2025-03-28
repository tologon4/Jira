using AutoMapper;
using Jira.Application.Avatars;
using Jira.Application.Users.Commands.Login;
using Jira.Application.Users.Commands.SignIn;
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
}