using AutoMapper;
using Jira.Application.Projects.Commands.DeleteProject;
using Jira.Application.Projects.Queries.GetProjectListForProjectCreate;
using Jira.Application.ProjectTasks.Commands.ChangeStatus;
using Jira.Application.ProjectTasks.Commands.CreateProjectTask;
using Jira.Application.ProjectTasks.Commands.DeletePrjectTask;
using Jira.Application.ProjectTasks.Commands.EditProjectTask;
using Jira.Application.ProjectTasks.Queries.GetTaskForEdit;
using Jira.Domain.Enums;
using Jira.MVC.Models;
using Jira.MVC.Models.ProjectTaskModels;
using Microsoft.AspNetCore.Mvc;

namespace Jira.MVC.Controllers;

public class ProjectTaskController : BaseController
{
    private readonly IMapper _mapper;

    public ProjectTaskController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Get project task for editing 
    /// </summary>
    /// <param name="taskId">task ID</param>
    [HttpGet]
    public async Task<IActionResult> Edit(int taskId)
    {
        var query = new GetTaskForEditQuery(taskId);
        var result = await Mediator.Send(query);
        if (result.IsFailed)
            return Json("Error");
        return Json(_mapper.Map<TaskForEditVm>(result.Value));
    }

    /// <summary>
    /// Edit project task
    /// </summary>
    /// <param name="command">Edit project task data</param>
    [HttpPost]
    public async Task<string> Edit([FromBody]EditProjectTaskDto data)
    {
        var command = _mapper.Map<EditProjectTaskCommand>(data);
        command.UserId = UserId;
        var result = await Mediator.Send(command);
        return result.Value;
    }
    
    /// <summary>
    /// Create project task
    /// </summary>
    /// <param name="data">creating task data</param>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateProjectTaskDto data)
    {
        var command = _mapper.Map<CreateProjectTaskCommand>(data);
        command.AuthorId = UserId;
        var result = await Mediator.Send(command);
        if (result.IsFailed)
            return BadRequest(result.Errors.First().ToString() ?? string.Empty);
        
        return RedirectToAction("Details", "Project", new { projectId = data.ProjectId });
    }

    /// <summary>
    /// Project Task delete
    /// </summary>
    /// <param name="taskId">task ID</param>
    [HttpGet]
    public async Task<IActionResult> Delete(int taskId)
    {
        var result = await Mediator.Send(new DeleteProjectTaskCommand(taskId, UserId));
        if (result.IsFailed)
            return BadRequest(result.Errors);
        return Json(result.Value);
    }
    
    /// <summary>
    /// Changes status of project task
    /// </summary>
    /// <param name="taskId">Project task id</param>
    /// <param name="newStatus">New ProjectTask Status</param>
    [HttpGet]
    public async Task<ActionResult> ChangeStatus(int taskId, int newStatus)
    {
        var result = await Mediator.Send(
            _mapper.Map<ChangeTaskStatusCommand>(new ChangeTaskStatusCommand(taskId, (ProjectTaskStatus)newStatus)));
        return Ok(new { message = result });
    }
}