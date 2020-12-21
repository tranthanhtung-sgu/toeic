using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class ToeicOnlineContextFactory
    {
        public class ToeicOnlineContextContextFactory : IDesignTimeDbContextFactory<ToeicOnlineContext>
    {
        public ToeicOnlineContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MvcToeicContext");

            var optionsBuilder = new DbContextOptionsBuilder<ToeicOnlineContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ToeicOnlineContext(optionsBuilder.Options);
        }
    }
    }
}