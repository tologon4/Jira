namespace Jira.Persistance.DbInitializers;

public class DbInitializer
{
    public static void Initialize(JiraDbContext dbcontext)
    {
        dbcontext.Database.EnsureCreated();
    }
}