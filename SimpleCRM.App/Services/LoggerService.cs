using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class LoggerService
    {
        private IEmployeeRepository _employeeRepository;
        public LoggerService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<string> createLogLineByEmployee(int employeeId, string actionName, string newValueSet)
        {
            Employee employee = await _employeeRepository.GetEmployeeAsync(employeeId);
            string performedBy = employee.FullName + "@id_" + employeeId.ToString();

            return DateTime.Now + " | [ " + actionName + " ] [ " + newValueSet + " ] | action by [ " + performedBy + " ]" + Environment.NewLine;
        }
    }
}
