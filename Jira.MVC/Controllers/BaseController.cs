using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public abstract class BaseController : Controller
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    internal int UserId => !User.Identity.IsAuthenticated 
        ? -1 
        : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
}