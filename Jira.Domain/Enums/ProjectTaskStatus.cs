using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jira.Domain.Enums;

public enum ProjectTaskStatus
{
    [Description("To Do")]
    [Display(Name = "To Do")]
    ToDo = 1,
    [Description("In Progress")]
    [Display(Name = "In Progress")]
    InProgress,
    [Description("Done")]
    [Display(Name = "Done")]
    Done,
}