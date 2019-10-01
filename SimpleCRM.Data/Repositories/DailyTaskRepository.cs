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
    public class DailyTaskRepository : GenericRepository<DailyTask>, IDailyTaskRepository
    {
        public DailyTaskRepository(SimpleCRMContext context)
            : base(context)
        {
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<DailyTask, Employee> DailyTaskQuery()
        {
            return _context.DailyTasks.Include(e => e.Employee);
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTaskListAsync()
        {
            return await this.DailyTaskQuery().ToListAsync();
        }

        public async Task<DailyTask> GetDailyTaskAsync(int id)
        {
            return await this.DailyTaskQuery().FirstOrDefaultAsync(e => e.Id == id);
        }

    }
}
