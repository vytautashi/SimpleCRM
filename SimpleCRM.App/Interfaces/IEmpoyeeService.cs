using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCRM.App.Dto;

namespace SimpleCRM.App.Interfaces
{
    public interface IEmpoyeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeeListAsync();
        Task<EmployeeDto> GetEmployeeAsync(int id);
        Task<bool> AddEmployeeAsync(EmployeeDto employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id, EmployeeDto employee);
    }
}
