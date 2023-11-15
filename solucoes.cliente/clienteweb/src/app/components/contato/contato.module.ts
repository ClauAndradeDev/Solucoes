import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { ContatoComponent } from './contato.component';


@NgModule({
  providers: [],
  declarations: [ContatoComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule],
  exports: [ContatoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ContatoModule{}
