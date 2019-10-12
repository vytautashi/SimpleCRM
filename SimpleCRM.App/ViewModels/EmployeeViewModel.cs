using SimpleCRM.App.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.App.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeDto Employee { get; set; }
        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(EmployeeDto employeeDto)
        {
            this.Employee = employeeDto;
        }
    }
}
