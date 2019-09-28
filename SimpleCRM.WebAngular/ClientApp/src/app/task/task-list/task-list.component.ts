import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'api/dailytask';

@Component({
  selector: 'app-task',
  templateUrl: './task-list.component.html'
})
export class TaskComponent {
  public tasks: DailyTaskDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<DailyTaslListViewModel>(baseUrl + API_URL).subscribe(result => {
      this.tasks = result.dailyTasks;
    }, error => console.error(error));
  }
}
interface DailyTaslListViewModel {
  dailyTasks: DailyTaskDto[];
}

interface DailyTaskDto {
  dailyTaskId: number;
  title: string;
  description: string;

  employeeId: number;
  employeeFullName: string;
}
