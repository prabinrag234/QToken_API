using Microsoft.EntityFrameworkCore;
using QTokenAPI.EntityModels;

namespace QTokenAPI.DBContext
{
    public class QTokenDBContext : DbContext
    {
        public QTokenDBContext(DbContextOptions<QTokenDBContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}
