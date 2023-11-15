import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { GridviewComponent } from './gridview.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { EnderecoModule } from '../endereco/endereco.module';


@NgModule({
  providers: [],
  declarations: [GridviewComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatListModule, MatButtonModule, MatTableModule, EnderecoModule],
  exports: [GridviewComponent, EnderecoModule],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class GridViewModule{}
