using Microsoft.EntityFrameworkCore;
using System;

namespace TestWebApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbOptions):base(dbOptions)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Code = "Emp101", Name = "Tom", Gender = "Male", AnnualSalary = 5500, DateOfBirth = new DateTime(1988, 6, 25) },
                new Employee() { Code = "Emp102", Name = "Alex", Gender = "Male", AnnualSalary = 5700.95, DateOfBirth = new DateTime(1982, 9, 6) },
                new Employee() { Code = "Emp103", Name = "Mike", Gender = "Male", AnnualSalary = 5900, DateOfBirth = new DateTime(1979, 8, 12) },
                new Employee() { Code = "Emp104", Name = "Mary", Gender = "Female", AnnualSalary = 6500.826, DateOfBirth = new DateTime(1980, 10, 14) },
                new Employee() { Code = "Emp105", Name = "Nancy", Gender = "Female", AnnualSalary = 6700.826, DateOfBirth = new DateTime(1982, 12, 15) },
                new Employee() { Code = "Emp106", Name = "Steve", Gender = "Male", AnnualSalary = 7700.481, DateOfBirth = new DateTime(1979, 11, 18) }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
