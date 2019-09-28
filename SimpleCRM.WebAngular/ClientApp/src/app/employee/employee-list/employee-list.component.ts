import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'api/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  public employees: EmployeeDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<EmployeeListViewModel>(baseUrl + API_URL).subscribe(result => {
      this.employees = result.employees;
    }, error => console.error(error));
  }
}

export enum EmployeeOnlineStatus {
  Offline = 0,
  Online = 1,
  Away = 2,
}

interface EmployeeListViewModel {
  employees: EmployeeDto[];
}
interface EmployeeDto {
  employeeId: number;
  fullName: string;
  //address: string;
  //phone: string;
  //email: string;
  onlineStatus: number;
  onlineStatusText: string;
  roleName: string;
}
