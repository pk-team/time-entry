using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RWT.Infrastructure {
    public class DbContextFactory : IDesignTimeDbContextFactory<RWTDbContext> {
        public RWTDbContext CreateDbContext(string[] args) {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<RWTDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RWTDbContext(optionsBuilder.Options);
        }
    }
}