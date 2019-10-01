using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public static class DailyTaskConverter
    {
        public static DailyTask ToDailyTask(DailyTaskDto dailyTaskDto)
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

        public static DailyTaskDto ToDailyTaskDto(DailyTask dailyTask)
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

        public static IEnumerable<DailyTaskDto> ToDailyTaskDtoList(IEnumerable<DailyTask> dailyTasks)
        {
            ICollection<DailyTaskDto> dailyTasksDto = new Collection<DailyTaskDto>();
            foreach (var task in dailyTasks)
            {
                dailyTasksDto.Add(ToDailyTaskDto(task));
            }

            return dailyTasksDto;
        }

        public static DailyTaskListViewModel ToDailyTaskListViewModel(IEnumerable<DailyTask> dailyTasks)
        {
            return new DailyTaskListViewModel { DailyTasks = ToDailyTaskDtoList(dailyTasks) };
        }

        public static DailyTaskViewModel ToDailyTaskViewModel(DailyTask dailyTask)
        {
            DailyTaskDto dailyTaskDto = ToDailyTaskDto(dailyTask);

            return new DailyTaskViewModel{ DailyTask = dailyTaskDto };
        }



    }
}
