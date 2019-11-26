using SimpleCRM.App.Dto;
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
                Log = dailyTaskDto.Log,
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
                Log = dailyTask.Log,

                EmployeeId = dailyTask.Employee.Id,
                EmployeeFullName = dailyTask.Employee.FullName,
            };
            return dailyTaskDto;
        }
    }
}
