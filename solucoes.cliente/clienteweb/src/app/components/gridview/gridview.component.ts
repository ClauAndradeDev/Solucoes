import { EnderecoModule } from 'src/app/components/endereco/endereco.module';

import { EnderecoComponent } from './../endereco/endereco.component';
import { TipoEnderecoEnum } from './../../models/tipoEnderecoEnum.models';
import { Component, ViewChild, OnInit, Input } from '@angular/core';
import { MatTable, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionPanel } from '@angular/material/expansion';

export interface EnderecoElement {
  idEnderecoPessoa: number;
  tipoEndereco: number;
  tipoEnderecoPessoaDescricao: string;
  // logradouro: string;
  bairro: string;
  // cep: string;
  // cidade: string;
  // estado: string;
  edicao: boolean;
  exclusao: boolean;
}

const ELEMENT_ENDERECO: EnderecoElement[] = [
  { idEnderecoPessoa: 1, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Comercial', bairro: 'Zona Sul', edicao: true, exclusao: true },
  { idEnderecoPessoa: 2, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Residencial', bairro: 'Zona Sul', edicao: true, exclusao: true },
  { idEnderecoPessoa: 3, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Entrega', bairro: 'Zona Sul', edicao: true, exclusao: true },
  { idEnderecoPessoa: 4, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Cobrança', bairro: 'Zona Sul', edicao: true, exclusao: true },
  { idEnderecoPessoa: 5, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Cobrança', bairro: 'Zona Norte', edicao: true, exclusao: true },
];


@Component({
  selector: 'gridview',
  templateUrl: './gridview.component.html',
  styleUrls: ['./gridview.component.scss'],

})

export class GridviewComponent implements OnInit {
  constructor(public enderecoModule: EnderecoModule) { }

  ngOnInit(): void {

  }

  enderecoDataParaEnviar = {
    logradouro: '',
    bairro: '',
    selectTipoEndereco: 0,
    TipoEndereco: 0,
    cidade: '',
    cep: '',
    estado: '',
    numero: 0
  };


  @Input() valor: string;

  @Input()
  set abrirPainelEndereco(valor: Boolean) {
    // if(valor === true)
    // console.log('AbriPainelEndereço, gridview: ' + valor);
  }

  panelOpenState = false;

  displayedColumns: string[] = ['idEnderecoPessoa', 'tipoEndereco', 'tipoEnderecoPessoaDescricao', 'bairro', 'edicao', 'exclusao'];
  dataSource = [...ELEMENT_ENDERECO];



  @ViewChild(MatTable) table: MatTable<EnderecoElement>;
  @ViewChild(MatExpansionPanel, { static: true }) matExpansionPanelElement: MatExpansionPanel;
  @ViewChild('matExpansionPanel') matExpansionPanel: MatExpansionPanel;
  @ViewChild(EnderecoComponent) enderecoComponent: EnderecoComponent;


  abrirFocumario(panel: MatExpansionPanel, item:any){
    this.enderecoModule.carregandoEndereco(item);
  }

  salvarEndereco() {
    this.enderecoComponent.onSalvarEndereco();

    // let enderecoNovo = new Endereco();

    // //separador de logradouro
    // const logradouroArray = this.enderecoDataParaEnviar.logradouro.split(',');
    // const rua = logradouroArray[0].trim(); // remove espaços em branco extras
    // const numero = logradouroArray[1].trim(); // remov

    // enderecoNovo.Logradouro = rua;
    // enderecoNovo.Numero = numero;
    // enderecoNovo.TipoEndereco = this.enderecoDataParaEnviar.selectTipoEndereco;
    // enderecoNovo.Bairro = this.enderecoDataParaEnviar.bairro;
    // enderecoNovo.CEP = this.enderecoDataParaEnviar.cep;
    // enderecoNovo.Cidade = this.enderecoDataParaEnviar.cidade;
    // enderecoNovo.Estado = this.enderecoDataParaEnviar.estado;

    // //alert('Novo Endereço: ' + JSON.stringify(enderecoNovo, null, 2));
    // this.enderecoModule.salvarNovoEndereco(enderecoNovo);
    // //irá enviar para componente Endereço, salvar o endereço e retornar os dados do endereço para preencher o gridview
  }



  addData() {
    const randomElementIndex = Math.floor(Math.random() * ELEMENT_ENDERECO.length);

    this.dataSource.push(ELEMENT_ENDERECO[randomElementIndex]);
    this.table.renderRows();
  }

  updateData(tipopessoa: number) {
    //deve expandir o painel de endereços
    console.log('Clicou no botão Edição, nº: ' + tipopessoa);
    // const randomElementIndex = Math.floor(Math.random() * ELEMENT_ENDERECO.length);
    // this.dataSource.push(ELEMENT_ENDERECO[randomElementIndex]);
    // this.table.renderRows();
  }






  removeData(tipopessoa: number) {
    console.log('Clicou no botão Excluir, nº: ' + tipopessoa);
    this.dataSource.pop();
    this.table.renderRows();
  }
}
