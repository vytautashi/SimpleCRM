export interface DailyTaskDto {
  dailyTaskId: number;
  title: string;
  description: string;

  priority: number;
  status: number;
  statusText: string;
  log: string;

  employeeId: number;
  employeeFullName: string;
}
