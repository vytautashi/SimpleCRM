import { Component, Input, OnInit } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})

export class EmployeeTasksComponent {
  @Input()
  public employeeId: number;
  public tasks: DailyTaskDto[];
  public showEmployeeColumn;

  constructor(private service: DailyTaskService) {
  }

  ngOnInit() {
    this.showEmployeeColumn = this.employeeId === undefined ? true : false;

    if (this.employeeId === undefined) {
      this.getDailyTaskList(this.service.getDailyTasks());
    } else if (this.employeeId == 0) {
      this.getDailyTaskList(this.service.getMeDailyTasks());
    } else {
      this.getDailyTaskList(this.service.getDailyTasksByEmployeeId(this.employeeId));
    }
  }

  private getDailyTaskList(observable: Observable<any>) {
    observable.subscribe(result => { this.tasks = result.dailyTasks; }
      , error => console.error(error));
  }

}
