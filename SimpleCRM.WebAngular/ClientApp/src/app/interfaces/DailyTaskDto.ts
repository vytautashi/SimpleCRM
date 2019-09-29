export interface DailyTaskDto {
  dailyTaskId: number;
  title: string;
  description: string;

  priority: number;
  status: number;
  statusText: string;

  employeeId: number;
  employeeFullName: string;
}
