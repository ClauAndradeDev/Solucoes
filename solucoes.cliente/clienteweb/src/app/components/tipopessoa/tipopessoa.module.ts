import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { TipoPessoaComponent } from './tipopessoa.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  providers: [],
  declarations: [TipoPessoaComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatFormFieldModule],
  exports: [TipoPessoaComponent],
})

export class TipoPessoaModule{}
