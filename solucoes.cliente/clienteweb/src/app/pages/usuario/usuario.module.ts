import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuarioRoutingModule } from './usuario-routing.modules';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';
import { UsuarioComponent } from './usuario.component';


@NgModule({
  providers: [],
  declarations: [UsuarioComponent],
  imports: [CommonModule, UsuarioRoutingModule, NavbarModule, SideBarModule],
})
export class UsuarioModule {
  constructor(public menuService: MenuService) {}

  ngOnInit() {
    this.menuService.menuSelecionado = 3;
  }
}
