import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PessoaComponent } from './pessoa.component';
import { PessoaRoutingModule } from './pessoa-routing.modules';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';

@NgModule({
  providers: [],
  declarations: [PessoaComponent],
  imports: [
    CommonModule,
    PessoaRoutingModule,
    NavbarModule,
    FormsModule,
    SideBarModule,
    NgSelectModule,
  ],
  //exports: [CommonModule],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA],
})
export class PessoaModule {
  constructor(public menuService: MenuService) {}

  ngOnInit() {
    this.menuService.menuSelecionado = 2;
  }
}
