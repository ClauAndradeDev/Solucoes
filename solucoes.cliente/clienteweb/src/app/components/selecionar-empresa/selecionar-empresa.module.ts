import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SelecionarEmpresaComponent } from './selecionar-empresa.component';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  declarations: [SelecionarEmpresaComponent],
  imports: [CommonModule, FormsModule, NgSelectModule],
  exports: [SelecionarEmpresaComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SelecionarEmpresaModule{}
