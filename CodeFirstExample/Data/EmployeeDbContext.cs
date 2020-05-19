using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            //this.ChangeTracker.LazyLoadingEnabled = false;
            
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
            optionsBuilder.UseSqlServer(@"Server=.;Database=EmployeeDb;Trusted_Connection=True;",options=>
            {
              
            });

            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
             .HasOne(s => s.Department)
             .WithMany(ad => ad.Employees)
             .HasForeignKey(ad => ad.DepartmentId);
            //modelBuilder.Entity<Employee>().Property<DateTime>("CreatedDate").HasDefaultValue(DateTime.Now);

            var allEntities = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in allEntities)
            {
                if (entity.BaseType == null && entity.FindProperty("CreatedDate") == null)
                {
                    entity.AddProperty("CreatedDate", typeof(DateTime)).SetDefaultValue(DateTime.Now);
                }

                //if (entity.BaseType == null && entity.FindProperty("UpdatedDate") == null)
                //{
                //    entity.AddProperty("UpdatedDate", typeof(DateTime)).SetDefaultValue(DateTime.Now);
                //}

                //    if ( entityType.BaseType != null)
                //    {
                //        modelBuilder.Ignore(entityType.ClrType);
                //    }
            }


            //if (typeof(TEntity).BaseType == null)
            //    modelBuilder.Entity<Employee>().ToTable("Tbl_Employee");

            //modelBuilder.Entity<PermanentEmployee>().HasNoKey();
            //modelBuilder.Entity<ContractEmployee>().HasNoKey();
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, Name = "Admin" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, Name = "IT" });
            //modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");

            modelBuilder.Entity<TestEmployee>().HasKey(p => new { p.Id, p.EmployeeType });

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
        [ConcurrencyCheck]
        public string Name { get; set; }

        [Column(Order = 6)]
        
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
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
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
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
