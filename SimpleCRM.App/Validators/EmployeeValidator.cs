using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Validators
{
    public static class EmployeeValidator
    {
        public static bool isValid(Employee employee)
        {
            return CommonValidator.ValidateName(employee.FullName, true)
                && CommonValidator.ValidateName(employee.Address, false)
                && CommonValidator.ValidatePhone(employee.Phone, false)
                && CommonValidator.ValidateEmail(employee.Email, false);
        }
    }
}
