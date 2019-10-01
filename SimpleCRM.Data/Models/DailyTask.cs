using System.Collections.Generic;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class DailyTask : IEntity
    {
        public enum DailyTaskPriority
        {
            Lowest = 1,
            Low = 2,
            Normal = 3,
            Important = 4,
            Urgent = 5,
        }
        public enum DailyTaskStatus
        {
            Canceled = 0,
            Completed = 1,
            Ongoing = 2,
            Frozen = 3,
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DailyTaskPriority Priority { get; set; }
        public DailyTaskStatus Status { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
