import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu-left',
  templateUrl: './nav-menu-left.component.html',
  styleUrls: ['./nav-menu-left.component.css']
})
export class NavMenuLeftComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
