using System.ComponentModel;

namespace Jira.Domain.Enums;

public enum ProjectTaskStatus
{
    [Description("To Do")]
    ToDo = 1,
    [Description("In Progress")]
    InProgress,
    [Description("Done")]
    Done,
}