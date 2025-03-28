using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jira.Domain.Enums;

public enum ProjectTaskStatus
{
    [Description("Opened")]
    [Display(Name = "Opened")]
    Opened = 1,
    [Description("To Do")]
    [Display(Name = "To Do")]
    ToDo,
    [Description("In Progress")]
    [Display(Name = "In Progress")]
    InProgress,
    [Description("Done")]
    [Display(Name = "Done")]
    Done,
}