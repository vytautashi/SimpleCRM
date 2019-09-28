using System.Collections.Generic;

namespace SimpleCRM.Data.Models
{
    public class DailyTask
    {
        public int DailyTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public Employee Employee { get; set; }
    }
}
