using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Database
{
    public class Chain1DbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public Chain1DbContext(DbContextOptions<Chain1DbContext> dbOptions) : base(dbOptions)
        {
            Database.Migrate();
        }
    }

    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
