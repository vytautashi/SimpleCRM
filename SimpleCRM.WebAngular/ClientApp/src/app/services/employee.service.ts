import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

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

  deleteEmployee(id: number) {
    this.http.delete<any>(this.baseUrl + this.url + '/' + id, httpOptions)
      .subscribe(result => { });
  }

  addNewEmployee(employee) {
    this.http.post<any>(this.baseUrl + this.url, JSON.stringify(employee), httpOptions)
      .subscribe(result => {});
  }
}
