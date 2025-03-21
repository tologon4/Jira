using System.ComponentModel;

namespace Jira.Domain.Enums;

/// <summary>
/// Priority
/// </summary>
public enum Priority
{
    [Description("Низкий")]
    Low = 1,
    [Description("Средний")]
    Medium = 2,
    [Description("Высокий")]
    High = 3,
}