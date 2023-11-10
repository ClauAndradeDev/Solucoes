import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';

import { TicketComponent } from './ticket.component';
import { TicketRoutingModule } from './ticket-routing.modules';

@NgModule({
  providers: [],
  declarations: [TicketComponent],
  imports: [CommonModule, TicketRoutingModule, NavbarModule, SideBarModule],
})
export class TicketModule {
  constructor(public menuService: MenuService) {}

  ngOnInit() {
    this.menuService.menuSelecionado = 5;
  }
}
