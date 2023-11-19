import { CommonModule } from '@angular/common';
import { EnderecoComponent } from './endereco.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { Endereco } from 'src/app/models/endereco.model';
import { DadosEnderecosService } from 'src/app/services/dadosEnderecos.service';


@NgModule({
  providers: [],
  declarations: [EnderecoComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, NgSelectModule, MatExpansionModule],
  exports: [EnderecoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class EnderecoModule{

constructor(private dadosEnderecoService: DadosEnderecosService){}

carregandoEndereco(endereco: Endereco){
  //console.log('CarregandoEndereco, endereco.module ' + JSON.stringify(endereco, null, 2));
  this.dadosEnderecoService.atualizarDadosEndereco(endereco);
}

limparEndereco(){
  this.dadosEnderecoService.limparDadosEndereco();
}

atualizarDadosEndereco(endereco: any){}

  // salvarNovoEndereco(endereco: Endereco){
  //   alert('SalvarNovoEndereco, EnderecoModule: '+JSON.stringify(endereco, null, 2));
  // }
}
