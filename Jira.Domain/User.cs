using Microsoft.AspNetCore.Identity;

namespace Jira.Domain;

public class User : IdentityUser<long>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
}