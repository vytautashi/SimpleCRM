import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DailyTaskService {
  private url = 'api/dailytask';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getDailyTasks() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getDailyTasksByEmployeeId(id: number) {
    return this.http.get<any>(this.baseUrl + this.url + "/GetByEmployee/" + id);
  }
}
