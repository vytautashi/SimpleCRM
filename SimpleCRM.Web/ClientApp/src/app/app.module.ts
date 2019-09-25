import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NavMenuLeftComponent } from './nav-menu-left/nav-menu-left.component';
import { HomeComponent } from './home/home.component';
import { EmployeeComponent } from './employee/employee-list/employee-list.component';
import { TaskComponent } from './task/task-list/task-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
	  NavMenuLeftComponent,
	  HomeComponent,
    EmployeeComponent,
    TaskComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'employee', component: EmployeeComponent },
      { path: 'task', component: TaskComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
