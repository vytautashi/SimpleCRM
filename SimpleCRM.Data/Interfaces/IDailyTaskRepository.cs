using SimpleCRM.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCRM.Data.Interfaces
{
    public interface IDailyTaskRepository : IGenericRepository<DailyTask>
    {
        Task<IEnumerable<DailyTask>> GetListByEmployeeIdAsync(int id);
        Task<IEnumerable<DailyTask>> GetDailyTaskListAsync();
        Task<DailyTask> GetDailyTaskAsync(int id);
    }
}
