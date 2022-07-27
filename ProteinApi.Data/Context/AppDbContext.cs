using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ProteinApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Country> country { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Folder> folder { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
