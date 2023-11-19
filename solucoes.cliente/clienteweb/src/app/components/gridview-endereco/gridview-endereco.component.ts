import { Component, Input, ViewChild } from '@angular/core';
import { MatExpansionModule, MatExpansionPanel } from '@angular/material/expansion';
import { MatTable } from '@angular/material/table';
import { EnderecoComponent } from '../endereco/endereco.component';
import { EnderecoModule } from '../endereco/endereco.module';

export interface EnderecoElement {
  idEnderecoPessoa: number;
  tipoEndereco: number;
  tipoEnderecoPessoaDescricao: string;
  logradouro: string;
  bairro: string;
  numero: string;
  cep: string;
  cidade: string;
  estado: string;

}

const ELEMENT_ENDERECO: EnderecoElement[] = [
  { idEnderecoPessoa: 1, tipoEndereco: 2, tipoEnderecoPessoaDescricao: 'Comercial', logradouro: 'Rua da Andorinhas', numero: '123', cep: '89249-000', cidade: 'Itapoa', estado: 'SC', bairro: 'Zona Sul'},
  { idEnderecoPessoa: 2, tipoEndereco: 4, tipoEnderecoPessoaDescricao: 'Residencial', logradouro: 'Rua da Andorinhas', numero: '123', cep: '89249-000', cidade: 'Itapoa', estado: 'SC', bairro: 'Zona Sul'},
  { idEnderecoPessoa: 3, tipoEndereco: 3, tipoEnderecoPessoaDescricao: 'Entrega', logradouro: 'Rua da Andorinhas', numero: '123', cep: '89249-000', cidade: 'Itapoa', estado: 'SC', bairro: 'Zona Sul'},
  { idEnderecoPessoa: 4, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Cobrança', logradouro: 'Rua da Andorinhas', numero: '123', cep: '89249-000', cidade: 'Itapoa', estado: 'SC', bairro: 'Zona Sul'},
  { idEnderecoPessoa: 5, tipoEndereco: 1, tipoEnderecoPessoaDescricao: 'Cobrança', logradouro: 'Rua da Andorinhas', numero: '123', cep: '89249-000', cidade: 'Itapoa', estado: 'SC', bairro: 'Zona Norte'},
];


@Component({
  selector: 'gridview-endereco',
  templateUrl: './gridview-endereco.component.html',
  styleUrls: ['./gridview-endereco.component.scss']
})
export class GridviewEnderecoComponent {
  constructor(public enderecoModule: EnderecoModule) { }

  ngOnInit(): void {

  }

  enderecoDataParaEnviar = {
    logradouro: '',
    bairro: '',
    //selectTipoEndereco: 0,
    tipoEndereco: 0,
    cidade: '',
    cep: '',
    estado: '',
    numero: 0
  };


  @Input() valor: string;
  @Input()
  set abrirPainelEndereco(valor: Boolean) {

  }

  panelOpenState = false;

  displayedColumns: string[] = ['idEnderecoPessoa', 'tipoEnderecoPessoaDescricao', 'bairro', 'edicao', 'exclusao'];
  dataSource = [...ELEMENT_ENDERECO];



  @ViewChild(MatTable) table: MatTable<EnderecoElement>;
  @ViewChild(MatExpansionPanel, { static: true }) matExpansionPanelElement: MatExpansionPanel;
  @ViewChild('matExpansionPanel') matExpansionPanel: MatExpansionPanel;
  @ViewChild(EnderecoComponent) enderecoComponent: EnderecoComponent;


  abrirFormulario(panel: MatExpansionPanel, item:any){
    //console.log('AbrirFormulario, gridview-endereco ' + JSON.stringify(item, null, 2));
    this.enderecoModule.carregandoEndereco(item);
    panel.open();
  }

  fecharFormulario(panel: MatExpansionPanel){
    this.enderecoModule.limparEndereco();
    panel.close();
  }

  carregarPainel(valor: boolean){
    this.abrirPainelEndereco = true;
    console.log(this.abrirPainelEndereco);
  }

  salvarEndereco() {
    this.enderecoComponent.onSalvarEndereco();
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

