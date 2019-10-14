import { Component } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dailytask',
  templateUrl: './dailytask.viewpage.html',
})
export class DailyTaskViewpage {
  public dailyTask: DailyTaskDto;

  constructor(private service: DailyTaskService, route: ActivatedRoute) {
    service.getDailyTask(route.snapshot.paramMap.get('id')).subscribe(result => {
      this.dailyTask = result.dailyTask;
    }, error => console.error(error));
  }
}
