using SimpleCRM.App.Converters;
using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using SimpleCRM.App.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class EmployeeService : IEmpoyeeService
    {
        private IEmployeeRepository _employeeRepository;
        private EmployeeConverter _employeeConverter;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeConverter = new EmployeeConverter();
        }


        public async Task<IEnumerable<EmployeeDto>> GetEmployeeListAsync()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetEmployeeListAsync();

            return _employeeConverter.ToDtoList(employees);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            if (!await _employeeRepository.ExistsAsync(id))
            {
                return new EmployeeDto();
            }

            Employee employee = await _employeeRepository.GetEmployeeAsync(id);

            return _employeeConverter.ToDto(employee);
        }

        public async Task<bool> AddEmployeeAsync(EmployeeDto employee)
        {
            Employee employeeTemp = _employeeConverter.ToEmployee(employee);
            bool employeeValid = EmployeeValidator.isValid(employeeTemp);
            if (employeeValid)
            {
                await _employeeRepository.AddAsync(employeeTemp);
            }
            return employeeValid;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (await _employeeRepository.ExistsAsync(id))
            {
                await _employeeRepository.DeleteAsync(id);
            }
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDto employee)
        {
            Employee employeeTemp = _employeeConverter.ToEmployee(employee);
            if (EmployeeValidator.isValid(employeeTemp) && (await _employeeRepository.ExistsAsync(id)))
            {
                employeeTemp.Id = id;
                await _employeeRepository.UpdateAsync(employeeTemp);
            }
        }
    }
}
