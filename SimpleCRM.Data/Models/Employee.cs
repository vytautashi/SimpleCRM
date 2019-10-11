using System.Collections.Generic;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Online { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<DailyTask> DailyTasks { get; set; }
        public ICollection<Caller> Callers { get; set; }
    }
}