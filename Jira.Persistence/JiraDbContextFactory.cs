using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jira.Persistance
{
    public class JiraDbContextFactory : IDesignTimeDbContextFactory<JiraDbContext>
    {
        public JiraDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<JiraDbContext>();
            var connectionString = config.GetConnectionString("DBConnection");

            optionsBuilder.UseSqlite(connectionString);

            return new JiraDbContext(optionsBuilder.Options);
        }
    }
}