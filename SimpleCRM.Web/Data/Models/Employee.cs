﻿using System.Collections.Generic;

namespace SimpleCRM.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Connected { get; set; }

        public ICollection<DailyTask> DailyTasks { get; set; }
    }
}