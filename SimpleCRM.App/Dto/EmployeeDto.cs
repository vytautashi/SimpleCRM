using System.Collections.Generic;

namespace SimpleCRM.App.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Online { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<DailyTaskDto> DailyTasks { get; set; }
    }
}
