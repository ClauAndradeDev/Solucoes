import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { TipoPessoaComponent } from './tipopessoa.component';


@NgModule({
  providers: [],
  declarations: [TipoPessoaComponent],
  imports: [CommonModule, FormsModule, NgSelectModule],
  exports: [TipoPessoaComponent],
})

export class TipoPessoaModule{}
