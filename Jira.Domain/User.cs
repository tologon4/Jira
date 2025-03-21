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
    public string MiddleName { get; set; }
    /// <summary>
    /// User's Email Address 
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// URL for user's profile avatar
    /// </summary>
    public string AvatarUrl { get; set; }
}