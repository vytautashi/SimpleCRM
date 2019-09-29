using System.Collections.Generic;

namespace SimpleCRM.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Online { get; set; }

        public Role Role { get; set; }
        public ICollection<DailyTask> DailyTasks { get; set; }
    }
}