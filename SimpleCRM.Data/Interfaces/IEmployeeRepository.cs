using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id, Employee employee);
        Task<bool> ExistsEmployeeAsync(int id);
    }
}
