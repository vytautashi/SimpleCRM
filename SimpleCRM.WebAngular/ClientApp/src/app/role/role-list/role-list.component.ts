import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const API_URL = 'api/role';

@Component({
  selector: 'app-role',
  templateUrl: './role-list.component.html',
})
export class RoleComponent {
  public roles: RoleDto[];
  private base_url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl;
    http.get<RoleListViewModel>(baseUrl + API_URL).subscribe(result => {
      this.roles = result.roles;
    }, error => console.error(error));
  }

  @Output() notify: EventEmitter<any> = new EventEmitter<any>();
  selectChange(value: any) {
    this.notify.emit(value);
  }
}
interface RoleListViewModel {
  roles: RoleDto[];
}

interface RoleDto {
  roleId: number;
  name: string;
  description: string;
}
