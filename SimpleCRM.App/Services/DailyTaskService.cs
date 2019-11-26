using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.Converters;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System.Collections.Generic;
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


        public async Task<IEnumerable<DailyTaskDto>> GetListByEmployeeIdAsync(int id)
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetListByEmployeeIdAsync(id);

            return _dailyTaskConverter.ToDtoList(dailyTasks);
        }

        public async Task<IEnumerable<DailyTaskDto>> GetDailyTaskListAsync()
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskRepository.GetDailyTaskListAsync();

            return _dailyTaskConverter.ToDtoList(dailyTasks);
        }

        public async Task<DailyTaskDto> GetDailyTaskAsync(int id)
        {
            if (!await _dailyTaskRepository.ExistsAsync(id))
            {
                return new DailyTaskDto();
            }

            DailyTask dailyTask = await _dailyTaskRepository.GetDailyTaskAsync(id);

            return _dailyTaskConverter.ToDto(dailyTask);
        }

        public async Task<bool> AddDailyTaskAsync(DailyTaskDto dailyTask, int addByEmployeeId)
        {
            DailyTask dailyTaskTemp = _dailyTaskConverter.ToDailyTask(dailyTask);
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

        public async Task UpdateDailyTaskAsync(int id, DailyTaskDto dailyTask)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTask task = _dailyTaskConverter.ToDailyTask(dailyTask);
                task.Id = id;
                await _dailyTaskRepository.UpdateAsync(task);
            }
        }

        public async Task UpdateStatusDailyTaskAsync(int id, DailyTaskDto dailyTask, int updateByEmployeeId)
        {
            if (await _dailyTaskRepository.ExistsAsync(id))
            {
                DailyTaskDto taskFromDB = await GetDailyTaskAsync(id);
                taskFromDB.Status = dailyTask.Status;
                taskFromDB.Log = await _loggerService.createLogLineByEmployee(updateByEmployeeId, "Update Status", dailyTask.StatusText) + taskFromDB.Log;
                
                await UpdateDailyTaskAsync(id, taskFromDB);
            }
        }



    }
}
