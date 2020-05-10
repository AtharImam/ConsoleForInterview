using CodeFirstExample.Data;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dbcontext=new EmployeeDbContext())
            {
                var empl = dbcontext.Employees.FirstOrDefault(item => item.Name == "Athar");
                if (empl != null)
                {
                    empl.MobileNo = "45454545";
                }

                dbcontext.SaveChanges();
            }
        }
    }
}
