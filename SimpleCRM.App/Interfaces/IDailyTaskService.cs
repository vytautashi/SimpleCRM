using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCRM.App.Dto;

namespace SimpleCRM.App.Interfaces
{
    public interface IDailyTaskService
    {
        Task<IEnumerable<DailyTaskDto>> GetListByEmployeeIdAsync(int id);
        Task UpdateStatusDailyTaskAsync(int id, DailyTaskDto dailyTask, int updateByEmployeeId);

        Task<IEnumerable<DailyTaskDto>> GetDailyTaskListAsync();
        Task<DailyTaskDto> GetDailyTaskAsync(int id);
        Task<bool> AddDailyTaskAsync(DailyTaskDto dailyTask, int addByEmployeeId);
        Task DeleteDailyTaskAsync(int id);
        Task UpdateDailyTaskAsync(int id, DailyTaskDto dailyTask);
    }
}
