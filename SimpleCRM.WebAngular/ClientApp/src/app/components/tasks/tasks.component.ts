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
  public tasksAll: DailyTaskDto[];
  public tasks: DailyTaskDto[];
  public showEmployeeColumn;
  public hideCompleted: boolean = true;

  constructor(private service: DailyTaskService) {
  }

  toggleShowAll() {
    this.hideCompleted = !this.hideCompleted;
    this.filterDailyTasks();
  }

  filterDailyTasks() {
    if (this.hideCompleted)
      this.tasks = this.tasksAll.filter((item) => item.status != 1);
    else
      this.tasks = this.tasksAll;
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
    observable.subscribe(result => {
      this.tasksAll = result;
      this.tasks = this.tasksAll;
      this.filterDailyTasks();
    }
      , error => console.error(error));
  }

}
