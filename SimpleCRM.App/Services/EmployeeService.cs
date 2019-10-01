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

        private IEnumerable<DailyTaskDto> ToDailyTaskDtoList(IEnumerable<DailyTask> dailyTasks)
        {
            ICollection<DailyTaskDto> dailyTasksDto = new Collection<DailyTaskDto>();
            foreach (var dailyTask in dailyTasks)
            {
                dailyTasksDto.Add(new DailyTaskDto
                {
                    DailyTaskId = dailyTask.Id,
                    Title = dailyTask.Title,
                    Description = dailyTask.Description,
                    Priority = (int)dailyTask.Priority,
                    Status = (int)dailyTask.Status,
                    StatusText = dailyTask.Status.ToString(),

                    EmployeeId = dailyTask.Employee.Id,
                    EmployeeFullName = dailyTask.Employee.FullName,
                });
            }

            return dailyTasksDto;
        }
        private Employee ToEmployee(EmployeeDto employeeDto)
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
        private EmployeeDto ToEmployeeDto(Employee employee)
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
                DailyTasks = ToDailyTaskDtoList(employee.DailyTasks),
            };
            return employeeDto;
        }
        public async Task<EmployeeListViewModel> GetEmployeeListAsync()
        {
            IEnumerable<Employee> employees;
            Collection<EmployeeDto> employeesDto;

            employeesDto = new Collection<EmployeeDto>();
            employees = await _employeeRepository.GetEmployeeListAsync();

            foreach (var e in employees)
            {
                employeesDto.Add(ToEmployeeDto(e));
            }

            return new EmployeeListViewModel{Employees = employeesDto};
        }
        public async Task<EmployeeViewModel> GetEmployeeAsync(int id)
        {
            if (!await _employeeRepository.ExistsAsync(id))
            {
                return new EmployeeViewModel();
            }

            Employee employee;
            EmployeeDto employeeDto;

            employee = await _employeeRepository.GetEmployeeAsync(id);
            employeeDto = ToEmployeeDto(employee);

            return new EmployeeViewModel { Employee = employeeDto };
        }
        public async Task AddEmployeeAsync(EmployeeViewModel employee)
        {
            if (!EmployeeValidation(employee.Employee))
            {
                return;
            }
            Employee e = ToEmployee(employee.Employee);

            await _employeeRepository.AddAsync(e);
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
                Employee e = ToEmployee(employee.Employee);
                e.Id = id;

                await _employeeRepository.UpdateAsync(e);
            }
        }

        private bool EmployeeValidation(EmployeeDto employee)
        {
            return (employee.FullName.Length > 2)
                && (employee.FullName.Length < 60);
        }
    }
}
