using Jira.Domain;
using Microsoft.AspNetCore.Identity;

namespace Jira.Persistance.DbInitializers;

public class AdminInitializer
{
    public static async Task Initialize(UserManager<User> userManager)
    {
        string adminEmail = "admin@admin.com";
        string adminUsername = "admin";
        string adminPassword = "Admin1!";
        string path = "/userImages/defProf-ProfileN=1.png";
        var superadmin = new User()
        {
            Email = adminEmail,
            UserName = adminUsername,
            AvatarUrl = path,
            LastName = "Adminov",
            FirstName = "Admin",
            MiddleName = "Adminovich",
            PhoneNumber = "0",
        };
        IdentityResult result = await userManager.CreateAsync(superadmin, adminPassword);
    }
}