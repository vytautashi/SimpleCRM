import { Component, Input, OnInit } from '@angular/core';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
})
export class EmployeeComponent {
  @Input()
  public employeeId: number;
  public employee: EmployeeDto;

  constructor(private service: EmployeeService) {
  }

  ngOnInit() {
    this.service.getEmployee(this.employeeId).subscribe(result => {
      this.employee = result.employee;
    }, error => console.error(error));
  }

}
