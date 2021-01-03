using System;
using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Database
{
    public class Employee
    {
        [Key]
        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public double AnnualSalary { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
