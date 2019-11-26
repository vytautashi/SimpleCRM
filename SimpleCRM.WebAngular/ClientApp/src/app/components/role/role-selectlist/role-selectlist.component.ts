import { Component, Output, EventEmitter } from '@angular/core';
import { RoleDto } from 'src/app/interfaces/RoleDto';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'role-selectlist',
  templateUrl: './role-selectlist.component.html',
})
export class RoleSelectlistComponent {
  @Output()
  public notify: EventEmitter<any> = new EventEmitter<any>();
  public roles: RoleDto[];

  constructor(service: RoleService) {
    service.getRoles().subscribe(result => { this.roles = result; }
      , error => console.error(error));
  }

  selectChange(value: any) {
    this.notify.emit(value);
  }
}
