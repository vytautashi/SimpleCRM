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
                    DailyTaskId = dailyTask.DailyTaskId,
                    Title = dailyTask.Title,
                    Description = dailyTask.Description,
                    Priority = (int)dailyTask.Priority,
                    PriorityText = dailyTask.Priority.ToString(),
                    Status = (int)dailyTask.Status,
                    StatusText = dailyTask.Status.ToString(),

                    EmployeeId = dailyTask.Employee.EmployeeId,
                    EmployeeFullName = dailyTask.Employee.FullName,
                });
            }

            return dailyTasksDto;
        }
        private EmployeeDto ToEmployeeDto(Employee employee)
        {
            EmployeeDto employeeDto = new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                Address = employee.Address,
                Phone = employee.Phone,
                Email = employee.Email,
                OnlineStatus = (int) employee.OnlineStatus,
                OnlineStatusText = employee.OnlineStatus.ToString(),
                RoleId = employee.Role.RoleId,
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
            if (!await _employeeRepository.ExistsEmployeeAsync(id))
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
            Employee e = new Employee
            {
                FullName = employee.Employee.FullName,
            };
            await _employeeRepository.AddEmployeeAsync(e);
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            if (await _employeeRepository.ExistsEmployeeAsync(id))
            {
                await _employeeRepository.DeleteEmployeeAsync(id);
            }
        }
        public async Task UpdateEmployeeAsync(int id, EmployeeViewModel employee)
        {
            if (await _employeeRepository.ExistsEmployeeAsync(id))
            {
                Employee e = new Employee
                {
                    FullName = employee.Employee.FullName,
                    Address = employee.Employee.Address,
                    Phone = employee.Employee.Phone,
                };
                await _employeeRepository.UpdateEmployeeAsync(id, e);
            }
        }

        private bool EmployeeValidation(EmployeeDto employee)
        {
            return (employee.FullName.Length > 2)
                && (employee.FullName.Length < 60);
        }
    }
}
