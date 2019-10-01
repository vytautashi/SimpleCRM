using SimpleCRM.App.Converters;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class EmployeeService : IEmpoyeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task<EmployeeListViewModel> GetEmployeeListAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetEmployeeListAsync();

            return EmployeeConverter.ToEmployeeListViewModel(employees);
        }

        public async Task<EmployeeViewModel> GetEmployeeAsync(int id)
        {
            if (!await _employeeRepository.ExistsAsync(id))
            {
                return new EmployeeViewModel();
            }

            Employee employee = await _employeeRepository.GetEmployeeAsync(id);

            return EmployeeConverter.ToEmployeeViewModel(employee);
        }

        public async Task AddEmployeeAsync(EmployeeViewModel employee)
        {
            if (!EmployeeValidation(employee.Employee))
            {
                return;
            }
            Employee employeeTemp = EmployeeConverter.ToEmployee(employee.Employee);

            await _employeeRepository.AddAsync(employeeTemp);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (await _employeeRepository.ExistsAsync(id))
            {
                await _employeeRepository.DeleteAsync(id);
            }
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeViewModel employee)
        {
            if (await _employeeRepository.ExistsAsync(id))
            {
                Employee employeeTemp = EmployeeConverter.ToEmployee(employee.Employee);
                employeeTemp.Id = id;

                await _employeeRepository.UpdateAsync(employeeTemp);
            }
        }

        private bool EmployeeValidation(EmployeeDto employee)
        {
            return (employee.FullName.Length > 2)
                && (employee.FullName.Length < 60);
        }
    }
}
