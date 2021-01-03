using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Database
{
    public class Chain2DbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public Chain2DbContext(DbContextOptions<Chain2DbContext> dbOptions) : base(dbOptions)
        {
            Database.Migrate();
        }
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
