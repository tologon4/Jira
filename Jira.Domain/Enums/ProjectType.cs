using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jira.Domain.Enums;

public enum ProjectType
{
    [Description("Software Development")]
    [Display(Name = "Software Development")]
    SoftwareDevelopment = 1,
    [Description("Service Management")]
    [Display(Name = "Service Management")]
    ServiceManagement,
    [Description("Work Management")]
    [Display(Name = "Work Management")]
    WorkManagement,
    [Description("Product Management")]
    [Display(Name = "Product Management")]
    ProductManagement,
    [Description("Marketing")]
    [Display(Name = "Marketing")]
    Marketing,
    [Description("Working with Personnel")]
    [Display(Name = "Working with Personnel")]
    WorkingWithPersonnel
}