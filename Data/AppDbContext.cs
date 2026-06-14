using Microsoft.EntityFrameworkCore;
using PolicyStreetBackEnd.Models.Entities;

namespace PolicyStreetBackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
