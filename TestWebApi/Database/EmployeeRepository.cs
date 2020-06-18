using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Database
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext dbContext = null;

        public EmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this.dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(string code)
        {
            return await this.dbContext.Employees.FirstOrDefaultAsync(item => item.Code==code);
        }
    }
}
