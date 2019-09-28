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
    public class RoleRepository : IRoleRepository
    {
        private SimpleCRMContext _context;

        public RoleRepository(SimpleCRMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetListAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
