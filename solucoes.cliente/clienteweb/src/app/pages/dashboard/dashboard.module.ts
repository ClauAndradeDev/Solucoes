import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.modules';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';



@NgModule({
  providers: [],
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    NavbarModule,
    SideBarModule
  ],
})
export class DashboardModule {

  constructor(public menuService: MenuService)
  {

  }

  ngOnInit(){
    this.menuService.menuSelecionado = 1;
  }
}
