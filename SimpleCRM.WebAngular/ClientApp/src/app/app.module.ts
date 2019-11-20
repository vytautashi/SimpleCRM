import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from "@angular/common";

import { AppComponent } from './app.component';
import { NavMenuLeftComponent } from './menus/nav-menu-left/nav-menu-left.component';
import { HomeViewpage } from './viewpages/home/home.viewpage';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeComponent } from './components/employee/employee/employee.component';
import { RoleService } from './services/role.service';
import { RoleDropdownComponent } from './components/role/role-dropdown/role-dropdown.component';
import { DailyTaskService } from './services/dailytask.service';
import { EmployeeService } from './services/employee.service';
import { PriorityBarComponent } from './components/priority-bar/priority-bar.component';
import { EmployeeTasksComponent } from './components/tasks/tasks.component';
import { MyTasksViewpageComponent } from './viewpages/my-tasks/my-tasks-viewpage.component';
import { MyProfileViewpageComponent } from './viewpages/my-profile/my-profile-viewpage.component';
import { EmployeeViewpage } from './viewpages/employee/employee.viewpage';
import { EmployeeListViewpageComponent } from './viewpages/employee-list/employee-list-viewpage.component';
import { TaskListViewpageComponent } from './viewpages/task-list/task-list-viewpage.component';
import { EmployeeAddViewpageComponent } from './viewpages/employee-add/employee-add-viewpage.component';
import { DailyTaskAddViewpageComponent } from './viewpages/dailytask-add/dailytask-add-viewpage.component';
import { EmployeeSelectlistComponent } from './components/employee/employee-selectlist/employee-selectlist.component';
import { RoleSelectlistComponent } from './components/role/role-selectlist/role-selectlist.component';
import { CustomerListViewpage } from './viewpages/customer-list/customer-list.viewpage';
import { CustomerService } from './services/customer.service';
import { CustomerViewpage } from './viewpages/customer/customer.viewpage';
import { DailyTaskViewpage } from './viewpages/dailytask/dailytask.viewpage';
import { MyAuthService } from './services/myauth.service';
import { LoginComponent } from './components/login/login.component';
import { CompanyListViewpage } from './viewpages/company-list/company-list.viewpage';
import { CompanyService } from './services/company.service';
import { CompanyAddViewpage } from './viewpages/company-add/company-add.viewpage';
import { CompanyViewpage } from './viewpages/company/company.viewpage';

@NgModule({
  declarations: [
    AppComponent,
	  NavMenuLeftComponent,
    HomeViewpage,
    MyTasksViewpageComponent,
    MyProfileViewpageComponent,
    EmployeeViewpage,
    EmployeeListViewpageComponent,
    TaskListViewpageComponent,
    EmployeeAddViewpageComponent,
    DailyTaskAddViewpageComponent,
    CustomerListViewpage,
    CustomerViewpage,
    DailyTaskViewpage,
    CompanyListViewpage,
    CompanyAddViewpage,
    CompanyViewpage,

    EmployeeListComponent,
    EmployeeComponent,
    RoleDropdownComponent,
    EmployeeSelectlistComponent,
    RoleSelectlistComponent,
    PriorityBarComponent,
    EmployeeTasksComponent,
    LoginComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeViewpage, pathMatch: 'full' },
      { path: 'my-tasks', component: MyTasksViewpageComponent },
      { path: 'my-profile', component: MyProfileViewpageComponent },
      { path: 'customer', component: CustomerListViewpage },
      { path: 'customer/:id', component: CustomerViewpage },
      { path: 'employee', component: EmployeeListViewpageComponent },
      { path: 'employee/:id', component: EmployeeViewpage },
      { path: 'employee-add', component: EmployeeAddViewpageComponent },
      { path: 'task-add', component: DailyTaskAddViewpageComponent },
      { path: 'task', component: TaskListViewpageComponent },
      { path: 'task/:id', component: DailyTaskViewpage },
      { path: 'company/:id', component: CompanyViewpage },
      { path: 'company', component: CompanyListViewpage },
      { path: 'company-add', component: CompanyAddViewpage },
    ])
  ],
  providers: [
    RoleService,
    DailyTaskService,
    EmployeeService,
    CustomerService,
    MyAuthService,
    CompanyService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
