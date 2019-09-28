using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data.Context;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SimpleCRMContext _context;

        public EmployeeRepository(SimpleCRMContext context)
        {
            _context = context;
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Employee, Role> EmployeeQuery()
        {
            //var a = from t in _context.EmployeeDailyTasks
            //        join e in _context.Employees on e.EmployeeDailyTasks equals t
            //        select new { e.Company, e.EmployeeDailyTasks };

            return _context.Employees
                .Include(e => e.DailyTasks)
                .Include(e => e.Role);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            return await this.EmployeeQuery().ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await this.EmployeeQuery().FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            Employee employee = new Employee() { EmployeeId = id };

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            var e = await _context.Employees.FindAsync(id);

            if (e != null)
            {
                e.FullName = employee.FullName;
                e.Address = employee.Address;
                e.Phone = employee.Phone;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsEmployeeAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == id);
        }
    }
}
