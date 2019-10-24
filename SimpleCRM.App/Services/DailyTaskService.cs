using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SimpleCRM.App.Helpers;

namespace SimpleCRM.App.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private IDailyTaskRepository _dailyTaskRepository;
        private DailyTaskConverter _dailyTaskConverter;
        private IEmployeeRepository _employeeRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository, IEmployeeRepository employeeRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _dailyTaskConverter = new DailyTaskConverter();

            _employeeRepository = employeeRepository;
        }


        public async Task<DailyTaskListViewModel> GetListByEmployeeIdAsync(int id)
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetListByEmployeeIdAsync(id);

            return _dailyTaskConverter.ToDailyTaskListViewModel(dailyTasks);
        }

        public async Task<DailyTaskListViewModel> GetDailyTaskListAsync()
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetDailyTaskListAsync();

            return _dailyTaskConverter.ToDailyTaskListViewModel(dailyTasks);
        }

        public async Task<DailyTaskViewModel> GetDailyTaskAsync(int id)
        {
            if (!await _dailyTaskRepository.ExistsAsync(id))
            {
                return new DailyTaskViewModel();
            }

            DailyTask dailyTask = await _dailyTaskRepository.GetDailyTaskAsync(id);

            return _dailyTaskConverter.ToDailyTaskViewModel(dailyTask);
        }

        public async Task AddDailyTaskAsync(DailyTaskViewModel dailyTask, int addByEmployeeId)
        {
            string addBy = (await _employeeRepository.GetAsync(addByEmployeeId)).FullName;
            addBy += " #id:" + addByEmployeeId.ToString();

            DailyTask e = _dailyTaskConverter.ToDailyTask(dailyTask.DailyTask);
            e.Log = LoggerCommon.createLogLine(addBy, "Create DailyTask", "") + e.Log;
            await _dailyTaskRepository.AddAsync(e);
        }

        public async Task DeleteDailyTaskAsync(int id)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                await _dailyTaskRepository.DeleteAsync(id);
            }
        }

        public async Task UpdateDailyTaskAsync(int id, DailyTaskViewModel dailyTask)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTask task = _dailyTaskConverter.ToDailyTask(dailyTask.DailyTask);
                task.Id = id;
                await _dailyTaskRepository.UpdateAsync(task);
            }
        }

        public async Task UpdateStatusDailyTaskAsync(int id, DailyTaskViewModel dailyTask)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTaskViewModel taskFromDB = await GetDailyTaskAsync(id);
                taskFromDB.DailyTask.Status = dailyTask.DailyTask.Status;
                taskFromDB.DailyTask.Log = LoggerCommon.createLogLine("", "Update Status", dailyTask.DailyTask.StatusText) + taskFromDB.DailyTask.Log;

                await UpdateDailyTaskAsync(id, taskFromDB);
            }
        }



    }
}
