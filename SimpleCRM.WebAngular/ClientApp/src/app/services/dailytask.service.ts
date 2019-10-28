import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};

@Injectable()
export class DailyTaskService {
  private url = 'api/dailytask';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getMeDailyTasks() {
    return this.http.get<any>(this.baseUrl + this.url + "/GetMeTasks");
  }

  getDailyTasks() {
    return this.http.get<any>(this.baseUrl + this.url);
  }

  getDailyTask(id: string) {
    return this.http.get<any>(this.baseUrl + this.url + "/" + id);
  }

  getDailyTasksByEmployeeId(id: number) {
    return this.http.get<any>(this.baseUrl + this.url + "/GetByEmployee/" + id);
  }

  updateStatusDailyTask(id: string, dailyTask) {
    this.http.put<any>(this.baseUrl + this.url + "/UpdateStatus/" + id, JSON.stringify(dailyTask), httpOptions)
      .subscribe(result => { });
  }

  addNewDailyTask(dailyTask) {
    return this.http.post<any>(this.baseUrl + this.url, JSON.stringify(dailyTask), httpOptions);
  }
}
