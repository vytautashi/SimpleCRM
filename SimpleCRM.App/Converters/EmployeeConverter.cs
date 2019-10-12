using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class EmployeeConverter : GenericConverter<Employee, EmployeeDto>
    {
        public Employee ToEmployee(EmployeeDto employeeDto)
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

        public override EmployeeDto ToDto(Employee employee)
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

        public EmployeeListViewModel ToEmployeeListViewModel(IEnumerable<Employee> employees)
        {
            return new EmployeeListViewModel(ToDtoList(employees));
        }

        public EmployeeViewModel ToEmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel(ToDto(employee));
        }

    }
}
