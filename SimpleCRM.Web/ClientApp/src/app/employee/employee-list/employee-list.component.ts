import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'api/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee-list.component.html'
})
export class EmployeeComponent {
  public employees: employeeDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<employeeDto[]>(baseUrl + API_URL).subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }
}

interface employeeDto {
  employeeId: number;
  firstName: string;
  lastName: string;
  connected: boolean;
}
