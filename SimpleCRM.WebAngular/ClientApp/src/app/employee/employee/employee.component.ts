import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

const API_URL = 'api/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employee: EmployeeDto;
  private base_url: string; 

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    const GET_URL = "/" + this.route.snapshot.paramMap.get('id');
    http.get<EmployeeViewModel>(baseUrl + API_URL + GET_URL).subscribe(result => {
      this.employee = result.employee;
    }, error => console.error(error));
  }
}

interface EmployeeViewModel {
  employee: EmployeeDto;
}

interface DailyTaskDto
{
  dailyTaskId: number;
  title: string;
  description: string;
}

interface EmployeeDto {
  employeeId: number;
  fullName: string;
  address: string;
  phone: string;
  email: string;
  onlineStatus: number;
  roleName: string;
  dailyTasks: DailyTaskDto[];
}
