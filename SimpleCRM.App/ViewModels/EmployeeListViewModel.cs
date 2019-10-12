using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class EmployeeListViewModel
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
        public EmployeeListViewModel()
        {
        }

        public EmployeeListViewModel(IEnumerable<EmployeeDto> employeesDto)
        {
            this.Employees = employeesDto;
        }
    }
}
