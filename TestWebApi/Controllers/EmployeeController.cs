using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestWebApi.Database;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository repository = null;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await repository.GetEmployees();
        }

        [Route("detail/{code}")]
        public async Task<Employee> Get(string code)
        {
            return await repository.GetEmployee(code);
        }
    }
}
