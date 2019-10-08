using System;
using System.Collections.Generic;
using System.Text;
using SimpleCRM.Data.Interfaces;

namespace SimpleCRM.Data.Models
{
    public class IssueMessage : IEntity
    {
        public int Id { get; set; }
        public bool IsCustomer { get; set; }
        public string PosterId { get; set; } // EmployeeId or CustomerId
        public string PosterFullName { get; set; }
        public string MessageText { get; set; }

        public int IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
