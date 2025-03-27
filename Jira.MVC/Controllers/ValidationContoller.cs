using AutoMapper;
using FluentResults;
using Jira.Application.Users.Queries;
using Jira.Application.Users.Queries.UserNameCheck;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public class ValidationController : BaseController
{
    private readonly IMapper _mapper;

    public ValidationController(IMapper mapper) => _mapper = mapper;
        
    [AcceptVerbs("GET", "POST")]
    public async Task<IActionResult> DatesValid(DateTime StartDate, DateTime EndDate)
    {
        if (StartDate >= EndDate)
            return Json("EndDate must be later than StartDate!");
        return Json(true);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult EmailValid(string Email)
    {
        var result = Mediator.Send(new EmailCheckQuery(){Email = Email}).Result;
        if(result)
            return Json("Email is already in use!");
        return Json(true);
    }
    
    [AcceptVerbs("GET", "POST")]
    public IActionResult UserNameValid(string UserName)
    {
        var result = Mediator.Send(new UserNameCheckQuery(){UserName = UserName}).Result;
        if(result)
            return Json("UserName is already in use!");
        return Json(true);
    }
}
