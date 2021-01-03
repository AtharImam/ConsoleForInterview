using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWebApi.Database
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string code);
    }
}
