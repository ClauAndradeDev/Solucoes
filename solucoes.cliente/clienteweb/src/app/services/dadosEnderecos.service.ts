import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Endereco } from '../models/endereco.model';

@Injectable({
  providedIn: 'root'
})

export class DadosEnderecosService{
  constructor(){}

  private dadosEndereco = new BehaviorSubject<Endereco>(null);
  dadosEndereco$ = this.dadosEndereco.asObservable();

  atualizarDadosEndereco(dados: Endereco){
    // console.log(dados);
    // alert('AtualizarDadosEndereco, dadosEndereco.service: ' + JSON.stringify(dados, null, 2));
    this.dadosEndereco.next(dados);
  }

  limparDadosEndereco(){
    const enderecoVazio: Endereco = {
      Id: null,
      Logradouro: null,
      Numero: null,
      Bairro: null,
      CEP: null,
      Cidade: null,
      Estado: null,
      tipoEndereco: null
    };
    this.dadosEndereco.next(enderecoVazio);
  }

}
