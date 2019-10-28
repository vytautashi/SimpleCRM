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
using SimpleCRM.App.Validators;

namespace SimpleCRM.App.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private IDailyTaskRepository _dailyTaskRepository;
        private DailyTaskConverter _dailyTaskConverter;
        private LoggerService _loggerService;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository, IEmployeeRepository employeeRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _dailyTaskConverter = new DailyTaskConverter();

            _loggerService = new LoggerService(employeeRepository);
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

        public async Task<bool> AddDailyTaskAsync(DailyTaskViewModel dailyTask, int addByEmployeeId)
        {
            DailyTask dailyTaskTemp = _dailyTaskConverter.ToDailyTask(dailyTask.DailyTask);
            bool dailyTaskValid = DailyTaskValidator.isValid(dailyTaskTemp);
            if (dailyTaskValid)
            {
                dailyTaskTemp.Log = await _loggerService.createLogLineByEmployee(addByEmployeeId, "Create DailyTask", "") + dailyTaskTemp.Log;
                await _dailyTaskRepository.AddAsync(dailyTaskTemp);
            }
            return dailyTaskValid;
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

        public async Task UpdateStatusDailyTaskAsync(int id, DailyTaskViewModel dailyTask, int updateByEmployeeId)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTaskViewModel taskFromDB = await GetDailyTaskAsync(id);
                taskFromDB.DailyTask.Status = dailyTask.DailyTask.Status;
                taskFromDB.DailyTask.Log = await _loggerService.createLogLineByEmployee(updateByEmployeeId, "Update Status", dailyTask.DailyTask.StatusText) + taskFromDB.DailyTask.Log;
                
                await UpdateDailyTaskAsync(id, taskFromDB);
            }
        }



    }
}
