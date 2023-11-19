import { InformacaoPessoaComponent } from './informacao-pessoa.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';



@NgModule({
  providers: [],
  declarations: [InformacaoPessoaComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatFormFieldModule],
  exports: [InformacaoPessoaComponent],
})

export class InformacaoPessoaModule{}
