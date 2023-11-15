import { CommonModule } from '@angular/common';
import { EnderecoComponent } from './endereco.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { Endereco } from 'src/app/models/endereco.model';


@NgModule({
  providers: [],
  declarations: [EnderecoComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, NgSelectModule, MatExpansionModule],
  exports: [EnderecoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class EnderecoModule{

  salvarNovoEndereco(endereco: Endereco){
    alert('SalvarNovoEndereco, EnderecoModule: '+JSON.stringify(endereco, null, 2));
  }
}
