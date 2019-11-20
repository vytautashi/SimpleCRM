import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-viewpage',
  templateUrl: './employee.viewpage.html',
})
export class EmployeeViewpage {
  public employeeId: string;

  constructor(route: ActivatedRoute) {
    this.employeeId = route.snapshot.paramMap.get('id');
  }
}
