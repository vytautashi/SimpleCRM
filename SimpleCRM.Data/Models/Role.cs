using System.Collections.Generic;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}