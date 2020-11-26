using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class ToeicOnlineContextFactory
    {
        public ToeicOnlineContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ToeicOnlineContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<ToeicOnlineContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MvcToeicContext"));

            return new ToeicOnlineContext(optionsBuilder.Options);
        }
    }
}