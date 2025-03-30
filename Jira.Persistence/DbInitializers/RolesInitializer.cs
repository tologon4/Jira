using Microsoft.AspNetCore.Identity;

namespace Jira.Persistance.DbInitializers;

public class RolesInitializer
{
    public static async Task InitializeAsync(RoleManager<IdentityRole<int>> roleManager)
    {
        var roleNames = new [] { "director", "pManager", "employee" };
        
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole<int>(roleName);
                await roleManager.CreateAsync(role);
            }
        }
        
    } 
}