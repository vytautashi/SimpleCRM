import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RoleService {
  private url = 'api/role';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getRoles() {
    return this.http.get<any>(this.baseUrl + this.url);
  }
}
