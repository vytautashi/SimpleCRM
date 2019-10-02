import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';

@Component({
  selector: 'app-employee-add-viewpage',
  templateUrl: './employee-add-viewpage.component.html',
})
export class EmployeeAddViewpageComponent {
  public employee = { "roleId": 0 };

  constructor(private service: EmployeeService) {
  }

  public assignRoleId(id: number) {
    this.employee.roleId = id;
  }

  public clickSubmit() {
    this.service.addNewEmployee({"employee": this.employee});
  }
}
