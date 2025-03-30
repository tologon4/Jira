using Microsoft.AspNetCore.Identity;

namespace Jira.Domain;
/// <summary>
/// User 
/// </summary>
public class User : IdentityUser<int>
{
    /// <summary>
    /// User's Family Name
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// User's Name
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// User's Middle Name
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// User's Email Address 
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// URL for user's profile avatar
    /// </summary>
    public string? AvatarUrl { get; set; }
    
    /// <summary>
    /// User's Projects where user is just employee 
    /// </summary>
    public ICollection<Project>? EmployeeProjects { get; set; }
    
    /// <summary>
    /// User's Projects where user is ProjectManager
    /// </summary>
    public ICollection<Project>? ManageProjects { get; set; }
    
    /// <summary>
    /// User's Projects where user created project
    /// </summary>
    public ICollection<Project>? CreatedProjects { get; set; }
    
    /// <summary>
    /// User's Tasks where user is executor
    /// </summary>
    public ICollection<ProjectTask>? ProjectTasks { get; set; }
}