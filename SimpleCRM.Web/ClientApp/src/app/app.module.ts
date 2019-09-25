import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NavMenuLeftComponent } from './nav-menu-left/nav-menu-left.component';
import { HomeComponent } from './home/home.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { EmployeeComponent } from './employee/employee/employee.component';
import { TaskComponent } from './task/task-list/task-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
	  NavMenuLeftComponent,
	  HomeComponent,
    EmployeeListComponent,
    EmployeeComponent,
    TaskComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'employee', component: EmployeeListComponent },
      { path: 'employee/:id', component: EmployeeComponent },
      { path: 'task', component: TaskComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
