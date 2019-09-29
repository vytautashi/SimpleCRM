import { Component } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
})

export class DailyTaskComponent {
  public tasks: DailyTaskDto[];

  constructor(service: DailyTaskService) {
    service.getDailyTasks().subscribe(result => {
      this.tasks = result.dailyTasks;
    }, error => console.error(error));
  }

}
