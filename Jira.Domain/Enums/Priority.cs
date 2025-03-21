using System.ComponentModel;

namespace Jira.Domain.Enums;

/// <summary>
/// Priority
/// </summary>
public enum Priority
{
    [Description("Low")]
    Low = 1,
    [Description("Medium")]
    Medium = 2,
    [Description("High")]
    High = 3,
}