import { Component } from '@angular/core';
import { DailyTaskService } from 'src/app/services/dailytask.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dailytask-add-viewpage',
  templateUrl: './dailytask-add.viewpage.html',
})
export class DailyTaskAddViewpage {
  public dailyTask = { "employeeId": 0 };
  public msgId: number = -1;
  public addForm: boolean = true;

  constructor(private service: DailyTaskService) {
  }

  public assignEmployeeId(id: number) {
    this.dailyTask.employeeId = id;
  }

  public clickSubmit() {
    this.addDailyTask(this.service.addNewDailyTask(this.dailyTask));
  }

  private addDailyTask(observable: Observable<any>) {
    observable.subscribe(result => {
      this.postDailyTaskStatus(true);
    }
      , error => {
        console.error(error);
        this.postDailyTaskStatus(false);
      });
  }
  private postDailyTaskStatus(success: boolean) {
    if (success) {
      this.msgId = 1;
      this.addForm = false;
      this.dailyTask = { "employeeId": 0 };
    } else {
      this.msgId = 0;
      this.addForm = true;
    }
  }
}
