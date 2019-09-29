export interface DailyTaskDto {
  dailyTaskId: number;
  title: string;
  description: string;

  priority: number;
  priorityText: string;
  status: number;
  statusText: string;

  employeeId: number;
  employeeFullName: string;
}
