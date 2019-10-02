import { Component, Output, EventEmitter } from '@angular/core';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'employee-selectlist',
  templateUrl: './employee-selectlist.component.html'
})
export class EmployeeSelectlistComponent {
  @Output()
  public notify: EventEmitter<any> = new EventEmitter<any>();
  public employees: EmployeeDto[];

  constructor(private service: EmployeeService) {
    service.getEmployees().subscribe(result => { this.employees = result.employees; }
      , error => console.error(error));
  }

  selectChange(value: any) {
    this.notify.emit(value);
  }
}
