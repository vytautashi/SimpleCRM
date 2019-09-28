import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'api/task';

@Component({
  selector: 'app-task',
  templateUrl: './task-list.component.html'
})
export class TaskComponent {
  public tasks: dailyTaskDto[];
  private base_url: string; 

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<dailyTaskDto[]>(baseUrl + API_URL).subscribe(result => {
      this.tasks = result;
    }, error => console.error(error));
  }
}

interface dailyTaskDto {
  dailyTaskId: number;
  title: string;
  description: string;

  employeeId: number;
  employeeFirstName: string;
  employeeLastName: string;
}
