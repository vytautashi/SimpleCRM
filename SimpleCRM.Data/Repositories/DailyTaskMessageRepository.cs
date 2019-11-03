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
    public class DailyTaskMessageRepository : GenericRepository<DailyTaskMessage>, IDailyTaskMessageRepository
    {
        public DailyTaskMessageRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<DailyTaskMessage, Employee> DailyTaskMessageQuery()
        {
            return _context.DailyTaskMessages.AsNoTracking().Include(e => e.Employee);
        }

    }
}
