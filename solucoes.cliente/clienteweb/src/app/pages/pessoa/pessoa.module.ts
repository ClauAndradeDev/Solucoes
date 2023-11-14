import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PessoaComponent } from './pessoa.component';
import { PessoaRoutingModule } from './pessoa-routing.modules';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';

import {MatExpansionModule} from '@angular/material/expansion';
import { SelecionarEmpresaModule } from 'src/app/components/selecionar-empresa/selecionar-empresa.module';
import { PerfilPessoaModule } from 'src/app/components/perfilpessoa/perfilpessoa.module';
import { PerfilPessoaComponent } from 'src/app/components/perfilpessoa/perfilpessoa.component';


@NgModule({
  providers: [MenuService, NavbarModule, SideBarModule],
  declarations: [PessoaComponent],
  imports: [
    CommonModule,
    PessoaRoutingModule,
    NavbarModule,
    FormsModule,
    SideBarModule,
    NgSelectModule,
    MatExpansionModule,
    SelecionarEmpresaModule,
    PerfilPessoaModule,
    ],
  exports: [CommonModule],

})
export class PessoaModule {}
