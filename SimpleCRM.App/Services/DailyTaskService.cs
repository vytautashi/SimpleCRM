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

        private DailyTask ToDailyTask(DailyTaskDto dailyTaskDto)
        {
            DailyTask dailyTask = new DailyTask
            {
                Title = dailyTaskDto.Title,
                Description = dailyTaskDto.Description,
                Priority = (DailyTask.DailyTaskPriority)dailyTaskDto.Priority,
                Status = (DailyTask.DailyTaskStatus)dailyTaskDto.Status,
                EmployeeId = dailyTaskDto.EmployeeId,
            };
            return dailyTask;
        }

        private DailyTaskDto ToDailyTaskDto(DailyTask dailyTask)
        {
            DailyTaskDto dailyTaskDto = new DailyTaskDto
            {
                DailyTaskId = dailyTask.Id,
                Title = dailyTask.Title,
                Description = dailyTask.Description,
                Priority = (int)dailyTask.Priority,
                Status = (int)dailyTask.Status,
                StatusText = dailyTask.Status.ToString(),

                EmployeeId = dailyTask.Employee.Id,
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
            if (!await _dailyTaskRepository.ExistsAsync(id))
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
            DailyTask e = ToDailyTask(dailyTask.DailyTask);
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
                DailyTask e = ToDailyTask(dailyTask.DailyTask);
                e.Id = id;
                await _dailyTaskRepository.UpdateAsync(e);
            }
        }
    }
}
