using System;

namespace SimpleCRM.App.Dto
{
    public class DailyTaskMessageDto
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string MessageText { get; set; }
        public string PosterFullName { get; set; }
        public DateTime DateTime { get; set; }

        public int DailyTaskId { get; set; }
        public int EmployeeId { get; set; }
    }
}
