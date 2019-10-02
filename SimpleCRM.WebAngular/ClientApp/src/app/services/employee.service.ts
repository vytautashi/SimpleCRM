import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeService {
  private url = 'api/employee';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getEmployees() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getEmployee(id: number) {
    return this.http.get<any>(this.baseUrl + this.url + "/" + id);
  }

}
