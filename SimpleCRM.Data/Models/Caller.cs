using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCRM.Data.Models
{
    public class Caller
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int CallDurationInSeconds { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Comment { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
