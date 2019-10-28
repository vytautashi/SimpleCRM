using SimpleCRM.Data.Models;
using SimpleCRM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Interfaces
{
    public interface IEmpoyeeService
    {
        Task<EmployeeListViewModel> GetEmployeeListAsync();
        Task<EmployeeViewModel> GetEmployeeAsync(int id);
        Task<bool> AddEmployeeAsync(EmployeeViewModel employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(int id, EmployeeViewModel employee);
    }
}
