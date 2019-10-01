using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task DeleteAsync(int id);
        Task AddAsync(Employee dailyTask);
        Task UpdateAsync(Employee dailyTask);
        Task<bool> ExistsAsync(int id);

        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<Employee> GetEmployeeAsync(int id);
    }
}
