import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { ContatoModule } from '../contato/contato.module';
import { GridviewContatoComponent } from './gridviewContato.component';
import { ContatoComponent } from '../contato/contato.component';


@NgModule({
  providers: [],
  declarations: [GridviewContatoComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatListModule, MatButtonModule, MatTableModule, ContatoModule],
  exports: [GridviewContatoComponent, ContatoModule],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class GridViewContatoModule{}
