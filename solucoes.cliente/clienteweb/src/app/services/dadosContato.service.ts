import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Contato } from '../models/contato.model';

@Injectable({
  providedIn: 'root'
})
export class DadosContatoService {

  constructor() { }


  private dadosContato = new BehaviorSubject<Contato>(null);
  dadosContato$ = this.dadosContato.asObservable();

  atualizarDadosContato(dados: Contato) {
    //console.log('dadosContato.Service Json: '+ JSON.stringify(dados, null, 2));
    this.dadosContato.next(dados);
  }

  limparDadosContato() {
    const contatoVazio: Contato = {
      Id: null,
      tipoContato: null,
      nome: '',
      Telefone: '',
      Email: '',
      Situacao: 0
      //IdPessoa = null
      // Adicione outros campos conforme necessário
    };
    this.dadosContato.next(contatoVazio);
  }
}
