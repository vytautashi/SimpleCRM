using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IDailyTaskRepository
    {
        Task DeleteAsync(int id);
        Task AddAsync(DailyTask dailyTask);
        Task UpdateAsync(DailyTask dailyTask);
        Task<bool> ExistsAsync(int id);

        Task<IEnumerable<DailyTask>> GetDailyTaskListAsync();
        Task<DailyTask> GetDailyTaskAsync(int id);
    }
}
