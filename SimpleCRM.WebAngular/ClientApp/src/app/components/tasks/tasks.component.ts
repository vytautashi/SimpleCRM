import { Component, Input, OnInit } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})

export class EmployeeTasksComponent {
  @Input()
  public employeeId: number;
  public tasks: DailyTaskDto[];

  constructor(private service: DailyTaskService) {
  }

  ngOnInit() {
    this.service.getDailyTasksByEmployeeId(this.employeeId).subscribe(result => {
      this.tasks = result.dailyTasks;
    }, error => console.error(error));
  }

}
