using System.ComponentModel;

namespace Jira.Domain.Enums;

public enum ProjectPriority
{
    [Description("Низкий")]
    Low = 1,
    [Description("Средний")]
    Medium = 2,
    [Description("Высокий")]
    High = 3,
}