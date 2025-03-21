using System.ComponentModel;

namespace Jira.Domain.Enums;

public enum ProjectTaskType
{
    [Description("Task")]
    Task = 1,
    [Description("Bug")]
    Bug,
    [Description("History")]
    History,
    [Description("Epic")]
    Epic,
}