using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using EfCore = Microsoft.EntityFrameworkCore;

namespace CodeFirstExample.Data
{
    public class EmployeeDbContext : EfCore.DbContext
    {
        public EmployeeDbContext()
        {
         //this.Database.ExecuteSqlCommand  
         //this.Employees.FromSql
         //this.Employees.FromSqlRaw
       
        }

        public EfCore.DbSet<Employee> Employees { get; set; }

        public EfCore.DbSet<PermanentEmployee> PermanentEmployes { get; set; }

        public EfCore.DbSet<ContractEmployee> ContractEmployees { get; set; }

        public EfCore.DbSet<Department> Departments { get; set; }

        public EfCore.DbSet<PersonTph> PeopleTph { get; set; }
        public EfCore.DbSet<CustomerTph> CustomersTph { get; set; }
        public EfCore.DbSet<EmployeeTph> BaseEmployeesTph { get; set; }

        public EfCore.DbSet<PersonTpt> PeopleTpt { get; set; }
        public EfCore.DbSet<CustomerTpt> CustomersTpt { get; set; }
        public EfCore.DbSet<EmployeeTpt> EmployeesTpt { get; set; }

        public EfCore.DbSet<BillingDetail> BillingDetails { get; set; }

        public EfCore.DbSet<TestEmployee> TestEmployees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=EmployeeDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (typeof(TEntity).BaseType == null)
            //    modelBuilder.Entity<Employee>().ToTable("Tbl_Employee");

            //modelBuilder.Entity<PermanentEmployee>().HasNoKey();
            //modelBuilder.Entity<ContractEmployee>().HasNoKey();
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 1, Name = "Admin" });
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 2, Name = "IT" });
            //modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            //modelBuilder.Entity<CreditCard>().ToTable("CreditCards");

            modelBuilder.Entity<TestEmployee>().HasKey(p => new { p.Id, p.EmployeeType });

            //var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            //foreach (var entityType in entityTypes)
            //{
            //    if (entityType.BaseType != null)
            //    {
            //        modelBuilder.Ignore(entityType.ClrType);
            //    }
            //}

            var emp1 = new Employee
            {
                EmpId = 1,
                DepartmentId = 1,
                EmailId = "äbc@xyz.com",
                Name = "Athar",
                Gender = "Male",
                MobileNo = "9999999999"
            };

            var emp2 = new Employee
            {
                EmpId = 2,
                DepartmentId = 2,
                EmailId = "ddd@xyz.com",
                Name = "Shaheen",
                Gender = "FeMale",
                MobileNo = "888888"
            };

            modelBuilder.Entity<Employee>().HasData(emp1);

            modelBuilder.Entity<Employee>().HasData(emp2);

            //modelBuilder.Entity<PermanentEmployee>().HasData(new PermanentEmployee
            //{
            //    PEId=1,
            //    EmpId = 1,
            //    AnnualSalary = 200000
            //});

            //modelBuilder.Entity<ContractEmployee>().HasData(new ContractEmployee
            //{
            //    CEId=1,
            //    EmpId = 2,
            //    HourlySalary = 500
            //});

            base.OnModelCreating(modelBuilder);
        }
    }

    public class TestEmployee
    {
        [Key]
        public int Id { get; set; }

        [Key]
        public string EmployeeType { get; set; }

        public string Name { get; set; }
    }

    public class Employee
    {
        [Key]
        [Column(Order = 1)]
        public int EmpId { get; set; }

        [Column(Order = 4)]
        public string Gender { get; set; }

        [Column(Order = 3)]
        public string MobileNo { get; set; }

        [Column(Order = 5)]
        public string EmailId { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        [Column(Order = 6)]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }

    public class PermanentEmployee
    {
        [Key]
        public int PEId { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmpId { get; set; }

        public Employee Employee { get; set; }

        public decimal AnnualSalary { get; set; }
    }

    public class ContractEmployee
    {
        [Key]
        public int CEId { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmpId { get; set; }

        public Employee Employee { get; set; }

        public decimal HourlySalary { get; set; }
    }

    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        public string Name { get; set; }

        public List<Department> Departments { get; set; }
    }

    public class PersonTph
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerTph : PersonTph
    {
        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeTph : PersonTph
    {
        public decimal Turnover { get; set; }
    }

    public class PersonTpt
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerTpt
    {
        [ForeignKey(nameof(Person))]
        public Guid Id { get; set; } // PK and FK pointing to PersonTpt
        public PersonTpt Person { get; set; }

        public DateTime DateOfBirth { get; set; }
    }

    public class EmployeeTpt
    {
        [ForeignKey(nameof(Person))]
        public Guid Id { get; set; } // PK and FK pointing to PersonTpt
        public PersonTpt Person { get; set; }

        public decimal Turnover { get; set; }
    }
}
