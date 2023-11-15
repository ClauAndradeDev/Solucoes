import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PerfilPessoaComponent } from './perfilpessoa.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatExpansionModule } from '@angular/material/expansion';


@NgModule({
  providers: [],
  declarations: [PerfilPessoaComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule],
  exports: [PerfilPessoaComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class PerfilPessoaModule{}
