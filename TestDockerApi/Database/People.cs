using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDockerApi.Database
{
    [Table("People")]
    public class People
    {
        [Key]
        public int Id { get; set; }

        public string  Name { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
