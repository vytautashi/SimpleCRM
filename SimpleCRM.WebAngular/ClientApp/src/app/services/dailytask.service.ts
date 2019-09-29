import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DailyTaskService {
  private url = 'api/dailytask';
  private baseUrl: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getDailyTasks() {
    return this.http.get<any>(this.baseUrl + this.url);
  }
}
