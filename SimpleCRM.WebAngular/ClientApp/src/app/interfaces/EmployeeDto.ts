import { DailyTaskDto } from './DailyTaskDto';

export interface EmployeeDto {
  employeeId: number;
  fullName: string;
  address: string;
  phone: string;
  email: string;
  onlineStatus: number;
  onlineStatusText: string;
  roleId: number;
  roleName: string;
  dailyTasks: DailyTaskDto[];
}
