import { Component } from '@angular/core';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  public employees: EmployeeDto[];
  private employeesAll: EmployeeDto[];

  constructor(private service: EmployeeService) {
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

  clickDeleteEmployee(id: number) {
    if (confirm("Are you sure to delete")) {
      this.service.deleteEmployee(id);
    }
  }


}
