import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};

@Injectable()
export class MyAuthService {
  private url = 'api/MyAuth';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getMyAuth() {
    return this.http.get<any>(this.baseUrl + this.url + "/GetAuth");
  }
}
