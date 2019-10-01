import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-viewpage',
  templateUrl: './employee-viewpage.component.html',
})
export class EmployeeViewpageComponent {
  public employeeId: string;

  constructor(route: ActivatedRoute) {
    this.employeeId = route.snapshot.paramMap.get('id');
  }
}
