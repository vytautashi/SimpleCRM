using System.Collections.Generic;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
