using System.Collections.Generic;

namespace SimpleCRM.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}