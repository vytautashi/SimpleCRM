import { Component } from '@angular/core';
import { DailyTaskService } from 'src/app/services/dailytask.service';

@Component({
  selector: 'app-dailytask-add-viewpage',
  templateUrl: './dailytask-add-viewpage.component.html',
})
export class DailyTaskAddViewpageComponent {
  public dailyTask = { "employeeId": 0 };

  constructor(private service: DailyTaskService) {
  }

  public assignEmployeeId(id: number) {
    this.dailyTask.employeeId = id;
  }

  public clickSubmit() {
    this.service.addNewDailyTask({ "dailyTask": this.dailyTask});
  }
}
