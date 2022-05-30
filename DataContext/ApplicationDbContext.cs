using DapperAndEntityFrameworkApp.Models;
using Microsoft.EntityFrameworkCore;


namespace DapperAndEntityFrameworkApp.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
