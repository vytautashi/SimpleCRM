using System.Collections.Generic;

namespace SimpleCRM.Data.Models
{
    public class Employee
    {
        public enum EmployeeOnlineStatus
        {
            Offline = 0,
            Online = 1,
            Away = 2,
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EmployeeOnlineStatus OnlineStatus { get; set; }

        public Role Role { get; set; }
        public ICollection<DailyTask> DailyTasks { get; set; }
    }
}