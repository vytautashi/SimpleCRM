using SimpleCRM.Data.Models;
using SimpleCRM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Interfaces
{
    public interface IDailyTaskService
    {
        Task<DailyTaskListViewModel> GetListByEmployeeIdAsync(int id);
        Task UpdateStatusDailyTaskAsync(int id, DailyTaskViewModel dailyTask);

        Task<DailyTaskListViewModel> GetDailyTaskListAsync();
        Task<DailyTaskViewModel> GetDailyTaskAsync(int id);
        Task AddDailyTaskAsync(DailyTaskViewModel dailyTask, int addByEmployeeId);
        Task DeleteDailyTaskAsync(int id);
        Task UpdateDailyTaskAsync(int id, DailyTaskViewModel dailyTask);
    }
}
