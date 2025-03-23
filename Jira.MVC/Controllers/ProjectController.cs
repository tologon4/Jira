using AutoMapper;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.Projects.Queries.GetProjectList;
using Jira.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public class ProjectController : BaseController
{
    private readonly IMapper _mapper;

    public ProjectController(IMapper mapper) => _mapper = mapper;
    // GET
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetProjectListQuery() { };
        var result = await Mediator.Send(query);
        if (result.IsFailed)
            return View(new ProjectListVm());
        return View(result.Value);
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto data)
    {
        var command = _mapper.Map<CreateProjectCommand>(data);
        command.CreatorId = UserId;
        var result = await Mediator.Send(command);
        return RedirectToAction("GetAll");
    }
}