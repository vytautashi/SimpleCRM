import { DailyTaskDto } from './DailyTaskDto';

export interface EmployeeDto {
  employeeId: number;
  fullName: string;
  address: string;
  phone: string;
  email: string;
  online: boolean;
  roleId: number;
  roleName: string;
  dailyTasks: DailyTaskDto[];
}
