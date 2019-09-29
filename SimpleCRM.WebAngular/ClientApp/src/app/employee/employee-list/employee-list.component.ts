import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeDto } from '../../interfaces/EmployeeDto';

const API_URL = 'api/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  public employees: EmployeeDto[];
  public employeesAll: EmployeeDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<EmployeeListViewModel>(baseUrl + API_URL).subscribe(result => {
      this.employeesAll = result.employees;
      this.employees = this.employeesAll;
    }, error => console.error(error));
  }

  filterByRole(roleId: number) {
    if (roleId == 0)
      this.employees = this.employeesAll;
    else
      this.employees = this.employeesAll.filter((item) => item.roleId == roleId);
  }
}

interface EmployeeListViewModel {
  employees: EmployeeDto[];
}
