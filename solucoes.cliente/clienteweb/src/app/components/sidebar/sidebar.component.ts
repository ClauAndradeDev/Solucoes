import { NumberSymbol } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {

  constructor(private router: Router, public menuService: MenuService) {}

  selectMenu(menu: number) {
    switch (menu) {
      case 1:
        this.router.navigate(['/dashboard']);
        break;
      case 2:
        this.router.navigate(['/pessoa']);
        break;
      case 3:
        this.router.navigate(['/usuario']);
        break;
      case 4:
        this.router.navigate(['/empresa']);
        break;
      case 5:
        this.router.navigate(['/ticket']);
        break;
      case 6:
        this.router.navigate(['/reuniao']);
        break;
      case 7:
        this.router.navigate(['/logout']);
        break;

      default:
        break;
    }

    this.menuService.menuSelecionado = menu;
  }
}
