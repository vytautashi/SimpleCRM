import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { EmployeeDto } from '../../interfaces/EmployeeDto';

const API_URL = 'api/employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent {
  public employee: EmployeeDto;
  private base_url: string; 

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    const GET_URL = "/" + this.route.snapshot.paramMap.get('id');
    http.get<EmployeeViewModel>(baseUrl + API_URL + GET_URL).subscribe(result => {
      this.employee = result.employee;
    }, error => console.error(error));
  }
}

interface EmployeeViewModel {
  employee: EmployeeDto;
}
