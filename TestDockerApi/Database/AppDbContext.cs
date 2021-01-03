using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDockerApi.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
            Database.Migrate();
        }
    }
}
