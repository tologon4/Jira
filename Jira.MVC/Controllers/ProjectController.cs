using System.Collections.ObjectModel;
using AutoMapper;
using Jira.Application.Avatars;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.Projects.Queries.GetProjectList;
using Jira.Application.Projects.Queries.GetProjectListForProjectCreate;
using Jira.Domain.Enums;
using Jira.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public class ProjectController : BaseController
{
    private readonly IMapper _mapper;

    public ProjectController(IMapper mapper) => _mapper = mapper;
    // GET
    public async Task<IActionResult> Index()
    {
        var query = new GetProjectListQuery() { };
        var result = await Mediator.Send(query);
        if (result.IsFailed)
            return View(new Collection<ProjectLookupDto>());
        return View(result.Value.Projects);
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

    /// <summary>
    /// Project creating page
    /// </summary>
    [HttpGet]
    public async Task<ActionResult> Create()
    {
        ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        ViewBag.ProjectTypes = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();
        var users = Mediator.Send(new GetUsersListForProjectCreateQuery()).Result.Value;
        ViewBag.Users = users;
        ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
        return View();
    }
    
    /// <summary>
    /// Project creating
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectDto data)
    {
        var command = _mapper.Map<CreateProjectCommand>(data);
        command.CreatorId = UserId;
        var result = await Mediator.Send(command);
        if (result.IsFailed)
            return View(data);
        return RedirectToAction("Index");
    }
}