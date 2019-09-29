import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from "@angular/common";

import { AppComponent } from './app.component';
import { NavMenuLeftComponent } from './nav-menu-left/nav-menu-left.component';
import { HomeComponent } from './home/home.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeComponent } from './components/employee/employee/employee.component';
import { RoleService } from './services/role.service';
import { RoleDropdownComponent } from './components/role-dropdown/role-dropdown.component';
import { DailyTaskService } from './services/dailytask.service';
import { DailyTaskComponent } from './components/task/task-list/task-list.component';
import { EmployeeService } from './services/employee.service';
import { PriorityBarComponent } from './components/priority-bar/priority-bar.component';

@NgModule({
  declarations: [
    AppComponent,
	  NavMenuLeftComponent,
	  HomeComponent,
    EmployeeListComponent,
    EmployeeComponent,
    DailyTaskComponent,
    RoleDropdownComponent,
    PriorityBarComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'employee', component: EmployeeListComponent },
      { path: 'employee/:id', component: EmployeeComponent },
      { path: 'task', component: DailyTaskComponent },
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
