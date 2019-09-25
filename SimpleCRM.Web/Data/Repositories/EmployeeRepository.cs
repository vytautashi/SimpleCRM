using Microsoft.EntityFrameworkCore;
using SimpleCRM.Data.Context;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private SimpleCRMContext _context;

        public EmployeeRepository(SimpleCRMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            return await _context.Employees.ToListAsync();
        }
		
        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
    }
}
