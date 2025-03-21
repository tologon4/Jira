using Jira.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jira.Persistance;
public class JiraDbContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    DbSet<User> Users { get; set; }
    DbSet<Project> Projects { get; set; }
}