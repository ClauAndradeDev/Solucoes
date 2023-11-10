import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';
import { ReuniaoComponent } from './reuniao.component';
import { ReuniaoRoutingModule } from './reuniao-routing.modules';


@NgModule({
  providers: [],
  declarations: [ReuniaoComponent],
  imports: [CommonModule, ReuniaoRoutingModule, NavbarModule, SideBarModule],
})
export class ReuniaoModule {
  constructor(public menuService: MenuService) {}

  ngOnInit() {
    this.menuService.menuSelecionado = 6;
  }
}
