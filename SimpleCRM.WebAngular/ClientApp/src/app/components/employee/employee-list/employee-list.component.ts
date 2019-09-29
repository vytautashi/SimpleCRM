import { Component } from '@angular/core';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  public employees: EmployeeDto[];
  private employeesAll: EmployeeDto[];

  constructor(service: EmployeeService) {
    service.getEmployees().subscribe(result => {
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
