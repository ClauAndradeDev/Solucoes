import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { ListaSelecaoComponent } from './lista-selecao.component';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  providers: [],
  declarations: [ListaSelecaoComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatListModule, MatButtonModule, MatTableModule],
  exports: [ListaSelecaoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ListaSelecaoModule{}
