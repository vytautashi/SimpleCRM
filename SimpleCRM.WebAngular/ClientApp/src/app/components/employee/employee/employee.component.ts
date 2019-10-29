import { Component, Input, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
})
export class EmployeeComponent {
  @Input()
  public employeeId: number;
  public employee: EmployeeDto;
  public msgId: number = -1;

  constructor(private service: EmployeeService) {
  }

  ngOnInit() {
    if (this.employeeId == 0) {
      this.getEmployee(this.service.getMeEmployee());
    } else {
      this.getEmployee(this.service.getEmployee(this.employeeId));
    }
  }

  private getEmployee(observable: Observable<any>) {
    observable.subscribe(result => { this.employee = result.employee; }
      , error => {
        console.error(error);
        this.msgId = 0;
      });
  }

}
