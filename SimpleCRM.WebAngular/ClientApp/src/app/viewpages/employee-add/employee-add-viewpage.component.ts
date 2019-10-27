import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employee-add-viewpage',
  templateUrl: './employee-add-viewpage.component.html',
})
export class EmployeeAddViewpageComponent {
  public employee = { "roleId": 0 };
  public msgId: number = -1;
  public addForm: boolean = true;

  constructor(private service: EmployeeService) {
  }

  public assignRoleId(id: number) {
    this.employee.roleId = id;
  }

  public clickSubmit() {
    this.addEmployee(this.service.addNewEmployee({ "employee": this.employee }));
    this.service.addNewEmployee({ "employee": this.employee });
  }

  private addEmployee(observable: Observable<any>) {
    observable.subscribe(result => {
      this.msgId = result;
      this.addForm = this.msgId == 1 ? false : true;
    }
      , error => console.error(error));
  }
}
