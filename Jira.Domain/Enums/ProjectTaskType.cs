using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jira.Domain.Enums;

public enum ProjectTaskType
{
    [Description("Task")]
    [Display(Name = "Task")]
    Task = 1,
    [Description("Bug")]
    [Display(Name = "Bug")]
    Bug,
    [Description("History")]
    [Display(Name = "History")]
    History,
    [Description("Epic")]
    [Display(Name = "Epic")]
    Epic,
}