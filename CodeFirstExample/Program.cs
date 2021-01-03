using CodeFirstExample.Data;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbcontext=new EmployeeDbContext())
            {
                //var empl = new Employee
                //{
                //    Gender = "Male",
                //    EmailId = "Imam@y.c",
                //    MobileNo = "453434",
                //    Name = "Imam",
                //    DepartmentId = 3,
                //    Department = new Department { DepartmentId = 3, Name = "HR" }
                //};

                //dbcontext.Employees.Attach(empl);
                //dbcontext.SaveChanges();

                var empl = dbcontext.Employees.Include(e=>e.Department).FirstOrDefault(item => item.Name == "Athar");
                dbcontext.Entry(empl).Reference(item => item.Department).Load();
                System.Console.WriteLine($"Name: {empl.Name}, Department: {empl.Department.Name}");

                var dept = dbcontext.Departments.Find(1);
                dbcontext.Entry(dept).Collection(item => item.Employees).Load();
                System.Console.WriteLine($"Name: {dept.Name}, Department: {dept.Employees[0].Name}");
                // var empl = dbcontext.Employees.FromSqlRaw("Select * From Employees Where Name = 'Athar'").First();
                //var pers = from p in dbcontext.Employees select p;
            }
        }
    }
}
