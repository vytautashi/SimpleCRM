namespace SimpleCRM.App.Dto
{
    public class DailyTaskDto
    {
        public int DailyTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
    }
}
