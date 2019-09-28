namespace SimpleCRM.App.Dto
{
    public class DailyTaskDto
    {
        public int DailyTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
