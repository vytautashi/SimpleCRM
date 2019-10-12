using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimpleCRM.App.Dto;
using SimpleCRM.App.ViewModels;
using SimpleCRM.Data.Models;

namespace SimpleCRM.App.Converters
{
    public class DailyTaskConverter : GenericConverter<DailyTask, DailyTaskDto>
    {
        public DailyTask ToDailyTask(DailyTaskDto dailyTaskDto)
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

        public override DailyTaskDto ToDto(DailyTask dailyTask)
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

        public DailyTaskListViewModel ToDailyTaskListViewModel(IEnumerable<DailyTask> dailyTasks)
        {
            return new DailyTaskListViewModel(ToDtoList(dailyTasks));
        }

        public DailyTaskViewModel ToDailyTaskViewModel(DailyTask dailyTask)
        {
            return new DailyTaskViewModel(ToDto(dailyTask));
        }



    }
}
