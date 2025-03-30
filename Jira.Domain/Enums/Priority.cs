using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jira.Domain.Enums;

/// <summary>
/// Priority
/// </summary>
public enum Priority
{
    [Description("Low")]
    [Display(Name = "Low")]
    Low = 1,
    [Description("Medium")]
    [Display(Name = "Medium")]
    Medium = 2,
    [Description("High")]
    [Display(Name = "High")]
    High = 3,
}