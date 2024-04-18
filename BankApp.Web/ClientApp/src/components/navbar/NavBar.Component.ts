import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  collapsed: boolean = true;

  constructor() { }

  toggleNavbar(): void {
    this.collapsed = !this.collapsed;
  }
}
