import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};

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

  addNewDailyTask(dailyTask) {
    this.http.post<any>(this.baseUrl + this.url, JSON.stringify(dailyTask), httpOptions)
      .subscribe(result => { });
  }
}
