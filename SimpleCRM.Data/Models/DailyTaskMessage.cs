using SimpleCRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Data.Models
{
    public class DailyTaskMessage : IEntity
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string MessageText { get; set; }
        public string PosterFullName { get; set; }
        public DateTime DateTime { get; set; }

        public int DailyTaskId { get; set; }
        public DailyTask DailyTask { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
