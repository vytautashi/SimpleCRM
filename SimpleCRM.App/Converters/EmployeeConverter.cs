using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public static class EmployeeConverter
    {
        public static Employee ToEmployee(EmployeeDto employeeDto)
        {
            Employee employee = new Employee
            {
                FullName = employeeDto.FullName,
                Address = employeeDto.Address,
                Phone = employeeDto.Phone,
                Email = employeeDto.Email,
                Online = employeeDto.Online,
                RoleId = employeeDto.RoleId,
            };
            return employee;
        }

        public static EmployeeDto ToEmployeeDto(Employee employee)
        {
            EmployeeDto employeeDto = new EmployeeDto
            {
                EmployeeId = employee.Id,
                FullName = employee.FullName,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                Online = employee.Online,
                RoleId = employee.Role.Id,
                RoleName = employee.Role.Name,
            };
            return employeeDto;
        }

        public static EmployeeListViewModel ToEmployeeListViewModel(IEnumerable<Employee> employees)
        {
            ICollection<EmployeeDto> employeesDto = new Collection<EmployeeDto>();

            foreach (var employee in employees)
            {
                employeesDto.Add(ToEmployeeDto(employee));
            }

            return new EmployeeListViewModel { Employees = employeesDto };
        }

        public static EmployeeViewModel ToEmployeeViewModel(Employee employee)
        {
            EmployeeDto employeeDto = ToEmployeeDto(employee);

            return new EmployeeViewModel { Employee = employeeDto };
        }

    }
}
