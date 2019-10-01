import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from "@angular/common";

import { AppComponent } from './app.component';
import { NavMenuLeftComponent } from './menus/nav-menu-left/nav-menu-left.component';
import { HomeViewpageComponent } from './viewpages/home/home-viewpage.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeComponent } from './components/employee/employee/employee.component';
import { RoleService } from './services/role.service';
import { RoleDropdownComponent } from './components/role-dropdown/role-dropdown.component';
import { DailyTaskService } from './services/dailytask.service';
import { DailyTaskComponent } from './components/task/task-list/task-list.component';
import { EmployeeService } from './services/employee.service';
import { PriorityBarComponent } from './components/priority-bar/priority-bar.component';
import { EmployeeTasksComponent } from './components/tasks/tasks.component';
import { MyTasksViewpageComponent } from './viewpages/my-tasks/my-tasks-viewpage.component';
import { MyProfileViewpageComponent } from './viewpages/my-profile/my-profile-viewpage.component';
import { EmployeeViewpageComponent } from './viewpages/employee/employee-viewpage.component';
import { EmployeeListViewpageComponent } from './viewpages/employee-list/employee-list-viewpage.component';
import { TaskListViewpageComponent } from './viewpages/task-list/task-list-viewpage.component';

@NgModule({
  declarations: [
    AppComponent,
	  NavMenuLeftComponent,
    HomeViewpageComponent,
    MyTasksViewpageComponent,
    MyProfileViewpageComponent,
    EmployeeViewpageComponent,
    EmployeeListViewpageComponent,
    TaskListViewpageComponent,
    EmployeeListComponent,
    EmployeeComponent,
    DailyTaskComponent,
    RoleDropdownComponent,
    PriorityBarComponent,
    EmployeeTasksComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeViewpageComponent, pathMatch: 'full' },
      { path: 'my-tasks', component: MyTasksViewpageComponent },
      { path: 'my-profile', component: MyProfileViewpageComponent },
      { path: 'employee', component: EmployeeListViewpageComponent },
      { path: 'employee/:id', component: EmployeeViewpageComponent },
      { path: 'task', component: TaskListViewpageComponent },
    ])
  ],
  providers: [
    RoleService,
    DailyTaskService,
    EmployeeService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
