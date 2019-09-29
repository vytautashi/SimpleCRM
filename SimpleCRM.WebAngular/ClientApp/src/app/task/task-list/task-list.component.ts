import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DailyTaskDto } from '../../interfaces/DailyTaskDto';

const API_URL = 'api/dailytask';

@Component({
  selector: 'app-task',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
})
export class TaskComponent {
  public tasks: DailyTaskDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<DailyTaskListViewModel>(baseUrl + API_URL).subscribe(result => {
      this.tasks = result.dailyTasks;
    }, error => console.error(error));
  }
}
interface DailyTaskListViewModel {
  dailyTasks: DailyTaskDto[];
}
