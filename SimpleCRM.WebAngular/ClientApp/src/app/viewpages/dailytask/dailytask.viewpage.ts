import { Component } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dailytask',
  templateUrl: './dailytask.viewpage.html',
  styleUrls: ['./dailytask.viewpage.css'],
})
export class DailyTaskViewpage {
  public dailyTask: DailyTaskDto;
  public showEditStatus: boolean = false;
  public displayLogs: boolean = true;
  public displayMessages: boolean = true;
  public msgId: number = -1;

  constructor(private service: DailyTaskService, private route: ActivatedRoute) {
    service.getDailyTask(route.snapshot.paramMap.get('id')).subscribe(result => {
      this.dailyTask = result;
    }, error => {
      console.error(error);
      this.msgId = 0;
    });
  }

  public updateStatus(value: any) {
    this.showEditStatus = false;
    this.dailyTask.status = value;
    this.dailyTask.statusText = DailyTaskStatus[value];
    this.service.updateStatusDailyTask(this.route.snapshot.paramMap.get('id') ,this.dailyTask);
  }
}

export enum DailyTaskStatus {
  Canceled = 0,
  Completed = 1,
  Ongoing = 2,
  Frozen = 3,
}
