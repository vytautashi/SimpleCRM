using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IDailyTaskRepository
    {
        Task<IEnumerable<DailyTask>> GetDailyTaskListAsync();
        Task<DailyTask> GetDailyTaskAsync(int id);
        Task AddDailyTaskAsync(DailyTask dailyTask);
        Task DeleteDailyTaskAsync(int id);
        Task UpdateDailyTaskAsync(int id, DailyTask dailyTask);
        Task<bool> ExistsDailyTaskAsync(int id);
    }
}
