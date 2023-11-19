import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { ContatoComponent } from './contato.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Contato } from 'src/app/models/contato.model';
import { DadosContatoService } from 'src/app/services/dadosContato.service';

@NgModule({
  providers: [DadosContatoService],
  declarations: [ContatoComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule, MatButtonModule, MatTableModule],
  exports: [ContatoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class ContatoModule{

  constructor(private dadosContatoService: DadosContatoService){}


  carregandoContato(contato: Contato){
    // alert('ContatoModule: '+JSON.stringify(contato, null, 2));
     //console.log('contatoModule, carregandoContato: '+JSON.stringify(contato, null, 2));

    this.dadosContatoService.atualizarDadosContato(contato);
  }

  limparContato(){
    this.dadosContatoService.limparDadosContato();
  }

  atualizarDadosContato(contato: any){}
}
