import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-add-viewpage',
  templateUrl: './employee-add.viewpage.html',
})
export class EmployeeAddViewpage {
  public employee = { "roleId": 0 };
  public msgId: number = -1;
  public addForm: boolean = true;

  constructor(private service: EmployeeService) {
  }

  public assignRoleId(id: number) {
    this.employee.roleId = id;
  }

  public clickSubmit() {
    this.addEmployee(this.service.addNewEmployee(this.employee));
  }

  private addEmployee(observable: Observable<any>) {
    observable.subscribe(result => {
      this.postEmployeeStatus(true);
    }
      , error => {
        console.error(error);
        this.postEmployeeStatus(false);
      });
  }
  private postEmployeeStatus(success: boolean) {
    if (success) {
      this.msgId = 1;
      this.addForm = false;
      this.employee = { "roleId": 0 };
    } else {
      this.msgId = 0;
      this.addForm = true;
    }
  }
}
