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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Employee, Role> EmployeeQuery()
        {
            return _context.Employees
                .AsNoTracking()
                .Include(e => e.Role);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            return await this.EmployeeQuery().ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await this.EmployeeQuery().FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
