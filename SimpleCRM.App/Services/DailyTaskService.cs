using SimpleCRM.App.Dto;
using SimpleCRM.App.Interfaces;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Interfaces;
using SimpleCRM.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.App.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private IDailyTaskRepository _dailyTaskRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
        }

        private DailyTaskDto ToDailyTaskDto(DailyTask dailyTask)
        {
            DailyTaskDto dailyTaskDto = new DailyTaskDto
            {
                DailyTaskId = dailyTask.DailyTaskId,
                Title = dailyTask.Title,
                Description = dailyTask.Description,

                EmployeeId = dailyTask.Employee.EmployeeId,
                EmployeeFullName = dailyTask.Employee.FullName,
            };
            return dailyTaskDto;
        }
        public async Task<DailyTaskListViewModel> GetDailyTaskListAsync()
        {
            IEnumerable<DailyTask> dailyTasks;
            Collection<DailyTaskDto> DailyTasksDto;

            DailyTasksDto = new Collection<DailyTaskDto>();
            dailyTasks = await _dailyTaskRepository.GetDailyTaskListAsync();

            foreach (var e in dailyTasks)
            {
                DailyTasksDto.Add(ToDailyTaskDto(e));
            }

            return new DailyTaskListViewModel{ DailyTasks = DailyTasksDto};
        }
        public async Task<DailyTaskViewModel> GetDailyTaskAsync(int id)
        {
            if (!await _dailyTaskRepository.ExistsDailyTaskAsync(id))
            {
                return new DailyTaskViewModel();
            }

            DailyTask dailyTask;
            DailyTaskDto dailyTaskDto;

            dailyTask = await _dailyTaskRepository.GetDailyTaskAsync(id);
            dailyTaskDto = ToDailyTaskDto(dailyTask);

            return new DailyTaskViewModel { DailyTask = dailyTaskDto };
        }
        public async Task AddDailyTaskAsync(DailyTaskViewModel dailyTask)
        {
            DailyTask e = new DailyTask
            {
                Title = dailyTask.DailyTask.Title,
            };
            await _dailyTaskRepository.AddDailyTaskAsync(e);
        }
        public async Task DeleteDailyTaskAsync(int id)
        {
            if (await _dailyTaskRepository.ExistsDailyTaskAsync(id))
            {
                await _dailyTaskRepository.DeleteDailyTaskAsync(id);
            }
        }
        public async Task UpdateDailyTaskAsync(int id, DailyTaskViewModel dailyTask)
        {
            if (await _dailyTaskRepository.ExistsDailyTaskAsync(id))
            {
                DailyTask e = new DailyTask
                {

                    Title = dailyTask.DailyTask.Title,
                    Description = dailyTask.DailyTask.Description,
                };
                await _dailyTaskRepository.UpdateDailyTaskAsync(id, e);
            }
        }
    }
}
