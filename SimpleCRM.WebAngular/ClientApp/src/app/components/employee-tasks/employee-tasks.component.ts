import { Component, Input, OnInit } from '@angular/core';
import { DailyTaskDto } from 'src/app/interfaces/DailyTaskDto';
import { DailyTaskService } from 'src/app/services/dailytask.service';

@Component({
  selector: 'employee-tasks',
  templateUrl: './employee-tasks.component.html',
  styleUrls: ['./employee-tasks.component.css'],
})

export class EmployeeTasksComponent {
  @Input()
  public employeeId: number;

  public tasks: DailyTaskDto[];
  public service: DailyTaskService;

  constructor(service: DailyTaskService) {
    this.service = service;
  }
  ngOnInit() {
    this.service.getDailyTasksByEmployeeId(this.employeeId).subscribe(result => {
      this.tasks = result.dailyTasks;
    }, error => console.error(error));
  }

}
