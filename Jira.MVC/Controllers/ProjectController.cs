using System.Collections.ObjectModel;
using AutoMapper;
using Jira.Application.Avatars;
using Jira.Application.Projects.Commands.CreateProject;
using Jira.Application.Projects.Commands.DeleteProject;
using Jira.Application.Projects.Commands.UpdateProject;
using Jira.Application.Projects.Queries.GetProjectDetails;
using Jira.Application.Projects.Queries.GetProjectForUpdate;
using Jira.Application.Projects.Queries.GetProjectList;
using Jira.Application.Projects.Queries.GetProjectListForProjectCreate;
using Jira.Domain.Enums;
using Jira.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

[Authorize]
public class ProjectController : BaseController
{
    private readonly IMapper _mapper;

    public ProjectController(IMapper mapper) => _mapper = mapper;
    
    /// <summary>
    /// All user's projects
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var query = new GetProjectListQuery(UserId);
        var result = await Mediator.Send(query);
        if (result.IsFailed)
            return View(new Collection<ProjectLookupDto>());
        return View(result.Value.Projects);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int projectId)
    {
        var query = new GetProjectForUpdateQuery(projectId);
        var result = await Mediator.Send(query);
        if (result.IsFailed)
            return RedirectToAction("Details", new { projectId = projectId });
        ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        ViewBag.ProjectTypes = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();
        var users = Mediator.Send(new GetUsersListForProjectCreateQuery(null)).Result.Value;
        ViewBag.Users = users;
        ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
        return View(_mapper.Map<EditProjectDto>(result.Value));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(EditProjectDto data)
    {
        var command = _mapper.Map<EditProjectCommand>(data);
        command.UserId = UserId;
        var result = await Mediator.Send(command);
        if (result.IsFailed)
        {
            ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
            ViewBag.ProjectTypes = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();
            var users = Mediator.Send(new GetUsersListForProjectCreateQuery(null)).Result.Value;
            ViewBag.Users = users;
            ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
            ModelState.AddModelError(string.Empty, result.Errors.First().ToString() ?? string.Empty);
            return View(data);
        }
        return RedirectToAction("Details", new { projectId = data.Id });
    }
    
    /// <summary>
    /// Delete project
    /// </summary>
    /// <param name="projectId">Project ID</param>
    [HttpGet]
    public async Task<IActionResult> Delete(int? projectId)
    {
        var command = _mapper.Map<DeleteProjectCommand>(projectId);
        var result = await Mediator.Send(command);
        if (result.IsFailed)
            return Json(new { error = result.Errors.First().ToString() ?? string.Empty });
        return RedirectToAction("Index", "Project");
    }
    
    /// <summary>
    /// Project details page with kanban desk 
    /// </summary>
    /// <param name="projectId">Project ID</param>
    [HttpGet]
    public async Task<IActionResult> Details(int projectId)
    {
        var project = Mediator
            .Send(new GetProjectDetailsQuery(projectId, UserId)).Result;
        if (project.IsFailed)
            return RedirectToAction("Login", "Account");
        ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        ViewBag.Types = Enum.GetValues(typeof(ProjectTaskType)).Cast<ProjectType>();
        ViewBag.Statuses = Enum.GetValues(typeof(ProjectTaskStatus)).Cast<ProjectTaskStatus>();
        var users = Mediator.Send(new GetUsersListForProjectCreateQuery(projectId)).Result.Value;
        ViewBag.Users = users;
        return View(project.Value);
    }

    /// <summary>
    /// Project creating page
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "director")]
    public async Task<ActionResult> Create()
    {
        ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        ViewBag.ProjectTypes = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();
        var users = Mediator
            .Send(new GetUsersListForProjectCreateQuery(null))
            .Result.Value;
        ViewBag.Users = users;
        ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
        return View();
    }
    
    /// <summary>
    /// Project creating
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "director")]
    public async Task<IActionResult> Create(CreateProjectDto data)
    {
        var command = _mapper.Map<CreateProjectCommand>(data);
        command.CreatorId = UserId;
        var result = await Mediator.Send(command);
        if (result.IsFailed)
        {
            ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
            ViewBag.ProjectTypes = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();
            var users = Mediator
                .Send(new GetUsersListForProjectCreateQuery(null))
                .Result.Value;
            ViewBag.Users = users;
            ViewBag.Avatars = Mediator.Send(new GetAllAvatarsQuery()).Result.Value;
            ModelState.AddModelError(string.Empty, result.Errors.First().ToString() ?? string.Empty);
            return View(data);
        }
        return RedirectToAction("Details", new {projectId = result.Value});
    }
}