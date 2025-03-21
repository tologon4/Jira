using System.ComponentModel;

namespace Jira.Domain.Enums;

public enum ProjectTaskStatus
{
    [Description("Надо сделать")]
    ToDo = 1,
    [Description("В процессе")]
    InProgress,
    [Description("Сделано")]
    Done,
}