import { Component, Output, EventEmitter } from '@angular/core';
import { RoleDto } from 'src/app/interfaces/RoleDto';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-role-dropdown',
  templateUrl: './role-dropdown.component.html',
})
export class RoleDropdownComponent {
  @Output()
  public notify: EventEmitter<any> = new EventEmitter<any>();
  public roles: RoleDto[];

  constructor(service: RoleService) {
    service.getRoles().subscribe(result => { this.roles = result.roles; }
      , error => console.error(error));
  }

  selectChange(value: any) {
    this.notify.emit(value);
  }
}
