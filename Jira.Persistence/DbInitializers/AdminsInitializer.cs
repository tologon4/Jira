using Jira.Domain;
using Microsoft.AspNetCore.Identity;

namespace Jira.Persistance.DbInitializers;

public class AdminsInitializer
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
        var admin = new User()
        {
            Email = "manager@manager.com",
            UserName = "manager",
            AvatarUrl = path,
            LastName = "Badminov",
            FirstName = "Badmin",
            MiddleName = "Badminovich",
            PhoneNumber = "1"
        };
        await userManager.CreateAsync(superadmin, adminPassword);
        await userManager.AddToRoleAsync(superadmin, "director");
        await userManager.CreateAsync(admin, adminPassword);
        await userManager.AddToRoleAsync(admin, "pManager");
    }
}