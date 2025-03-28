using AutoMapper;
using Jira.Application.Projects.Queries.GetProjectListForProjectCreate;
using Jira.Application.ProjectTasks.Commands.ChangeStatus;
using Jira.Application.ProjectTasks.Commands.CreateProjectTask;
using Jira.Domain.Enums;
using Jira.MVC.Models.ProjectTaskModels;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public class ProjectTaskController : BaseController
{
    private readonly IMapper _mapper;

    public ProjectTaskController(IMapper mapper) => _mapper = mapper;

    
    [HttpGet]
    public async Task<ActionResult> Create(int projectId)
    {
        ViewBag.Priorities = Enum.GetValues(typeof(Priority)).Cast<Priority>();
        ViewBag.Types = Enum.GetValues(typeof(ProjectTaskType)).Cast<ProjectType>();
        var users = Mediator.Send(new GetUsersListForProjectCreateQuery()
        {
            ProjectId = projectId
        }).Result.Value;
        ViewBag.Users = users;
        var projectTaskDto = new CreateProjectTaskDto();
        projectTaskDto.ProjectId = projectId;
        return View(projectTaskDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectTaskDto data)
    {
        var command = _mapper.Map<CreateProjectTaskCommand>(data);
        command.AuthorId = UserId;
        var result = await Mediator.Send(command);
        if (result.IsFailed)
            return View(data);
        return RedirectToAction("Details", "Project", new { projectId = data.ProjectId });
    }

    public async Task<ActionResult> ChangeStatus(int taskId, int newStatus)
    {
        var result = await Mediator.Send(
            _mapper.Map<ChangeTaskStatusCommand>(new ChangeTaskStatusCommand()
            {
                TaskId = taskId,
                Status = (ProjectTaskStatus)newStatus
            })
            );
        return Ok(new { message = result });
    }
}