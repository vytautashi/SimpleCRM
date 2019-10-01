import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeService {
  private url = 'api/employee';
  private baseUrl: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getEmployees() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getEmployee(id: number) {
    return this.http.get<any>(this.baseUrl + this.url + "/" + id);
  }

}
