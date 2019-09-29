import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RoleService {
  private url = 'api/role';
  private baseUrl: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getRoles() {
    return this.http.get<any>(this.baseUrl + this.url);
  }
}
