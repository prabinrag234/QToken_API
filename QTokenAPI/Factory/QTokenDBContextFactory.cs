using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QTokenAPI.DBContext;

namespace QTokenAPI.Factory
{
    public class QTokenDBContextFactory : IDesignTimeDbContextFactory<QTokenDBContext>
    {
        public QTokenDBContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<QTokenDBContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));

            return new QTokenDBContext(optionsBuilder.Options);
        }

    }
}
