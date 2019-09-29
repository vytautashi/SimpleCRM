import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDto } from 'src/app/interfaces/EmployeeDto';
import { EmployeeService } from 'src/app/services/employee.service';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent {
  public employee: EmployeeDto;

  constructor(private route: ActivatedRoute, service: EmployeeService) {
    let employeeId = this.route.snapshot.paramMap.get('id');

    service.getEmployee(employeeId).subscribe(result => {
      this.employee = result.employee;
    }, error => console.error(error));
  }

}
