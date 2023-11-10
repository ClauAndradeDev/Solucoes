import { Component } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent {

  constructor(public menuService: MenuService) {}

  ngOnInit() {
    this.menuService.menuSelecionado = 3;
  }

}
