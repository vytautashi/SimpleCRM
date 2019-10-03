using SimpleCRM.App.Converters;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using SimpleCRM.App.Validators;
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
            Employee employeeTemp = EmployeeConverter.ToEmployee(employee.Employee);
            if (EmployeeValidator.isValid(employeeTemp))
            {
                await _employeeRepository.AddAsync(employeeTemp);
            }
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
            Employee employeeTemp = EmployeeConverter.ToEmployee(employee.Employee);
            if (EmployeeValidator.isValid(employeeTemp) && (await _employeeRepository.ExistsAsync(id)))
            {
                employeeTemp.Id = id;
                await _employeeRepository.UpdateAsync(employeeTemp);
            }
        }
    }
}
