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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        //public async Task<IEnumerable<Role>> GetListAsync()
        //{
        //    return await _context.Roles.ToListAsync();
        //}
    }
}
