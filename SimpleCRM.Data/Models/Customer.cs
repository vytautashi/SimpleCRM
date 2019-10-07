using System;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastContacted { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
