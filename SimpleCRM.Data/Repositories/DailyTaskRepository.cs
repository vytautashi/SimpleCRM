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
    public class DailyTaskRepository : IDailyTaskRepository
    {
        private SimpleCRMContext _context;

        public DailyTaskRepository(SimpleCRMContext context)
        {
            _context = context;
        }

        private Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<DailyTask, Employee> DailyTaskQuery()
        {
            return _context.DailyTasks
                .Include(e => e.Employee);
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTaskListAsync()
        {
            return await this.DailyTaskQuery().ToListAsync();
        }
        public async Task<DailyTask> GetDailyTaskAsync(int id)
        {
            return await this.DailyTaskQuery().FirstOrDefaultAsync(e => e.DailyTaskId == id);
        }
        public async Task AddDailyTaskAsync(DailyTask dailyTask)
        {
            _context.DailyTasks.Add(dailyTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDailyTaskAsync(int id)
        {
            DailyTask employee = new DailyTask() { DailyTaskId = id };

            _context.DailyTasks.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDailyTaskAsync(int id, DailyTask dailyTask)
        {
            var e = await _context.DailyTasks.FindAsync(id);

            if (e != null)
            {
                e.Title = dailyTask.Title;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsDailyTaskAsync(int id)
        {
            return await _context.DailyTasks.AnyAsync(e => e.DailyTaskId == id);
        }
    }
}
