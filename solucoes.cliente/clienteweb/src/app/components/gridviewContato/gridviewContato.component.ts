import { Component, ViewChild, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {MatTable, MatTableModule} from '@angular/material/table';
import { MatExpansionPanel } from '@angular/material/expansion';
import { ContatoModule } from '../contato/contato.module';
import { ContatoComponent } from '../contato/contato.component';


export interface ContatoElement{
  idContato: number;
  tipoDescricao: string;
  contatoNome: string;
  contatoTelefone: string;
  contatoEmail: string;
  tipoContato: number;
}

const ELEMENT_CONTATO: ContatoElement[]=[
{idContato: 1, tipoContato: 1, tipoDescricao: 'Comercial', contatoNome: 'Fulano 1', contatoTelefone: '123456', contatoEmail: 'email@gmail.com'},
{idContato: 2, tipoContato: 3, tipoDescricao: 'Residencial', contatoNome: 'Fulano 2', contatoTelefone: '123456', contatoEmail: 'email@gmail.com'},
{idContato: 3, tipoContato: 2, tipoDescricao: 'Preferencial', contatoNome: 'Fulano 3', contatoTelefone: '123456', contatoEmail: 'email@gmail.com'},
{idContato: 4, tipoContato: 1, tipoDescricao: 'Comercial', contatoNome: 'Fulano 4', contatoTelefone: '123456', contatoEmail: 'email@gmail.com'},
{idContato: 5, tipoContato: 3, tipoDescricao: 'Resindencial', contatoNome: 'Fulano 5', contatoTelefone: '123456', contatoEmail: 'email@gmail.com'},
];



@Component({
  selector: 'gridviewContato',
  templateUrl: './gridviewContato.component.html',
  styleUrls: ['./gridviewContato.component.scss'],

})

export class GridviewContatoComponent implements OnInit {
  constructor( public contatoModule: ContatoModule) {}

  ngOnInit(): void {

  }

  contatoDataParaEnviar={
    idContato:0,
   // selectTipoContato: 0,
    tipoContato: 0,
    contatoNome: '',
    contatoTelefone:'',
    contatoEmail:'',
  }


  @Input() valor: string;

  @Input()
  set abrirPainelContato(valor:Boolean){
    //if(valor === true)
    //console.log('AbriPainelContato, gridview: ' + valor);


  }
  //@Input() contatoData: any;

  panelOpenState = false;

  displayedColumns: string[] = ['idContato', 'tipoDescricao','contatoNome', 'edicao','exclusao'];
  dataSource = [...ELEMENT_CONTATO];


  @ViewChild(MatTable) table: MatTable<ContatoElement>;
  @ViewChild(MatExpansionPanel, {static: true}) matExpansionPanelElement: MatExpansionPanel;
  @ViewChild('matExpansionPanel') matExpansionPanel: MatExpansionPanel;
  @ViewChild(ContatoComponent) contatoComponent: ContatoComponent;

  abrirFormulario(panel: MatExpansionPanel, item:any){
    this.contatoModule.carregandoContato(item);
    panel.open();
  }

  fecharFormulario(panel: MatExpansionPanel){
    this.contatoModule.limparContato();
    panel.close();
  }

  carregarPainel(valor: boolean){
    this.abrirPainelContato = true;
    console.log(this.abrirPainelContato);
  }

  salvarContato(){
    //console.log('dados para enviar ' + JSON.stringify(this.contatoDataParaEnviar, null, 2));
    this.contatoComponent.onSalvarContato();
  }

  addData() {
    const randomElementIndex = Math.floor(Math.random() * ELEMENT_CONTATO.length);
    this.dataSource.push(ELEMENT_CONTATO[randomElementIndex]);
    this.table.renderRows();
  }


  updateData(idContato: number) {
    //deve expandir o painel de endereços
    console.log('Clicou no botão Edição, nº: '+idContato);
    this.abrirPainelContato = true;
    // const randomElementIndex = Math.floor(Math.random() * ELEMENT_ENDERECO.length);
    // this.dataSource.push(ELEMENT_ENDERECO[randomElementIndex]);
    // this.table.renderRows();
  }



  removeData(idContato: number) {
    console.log('Clicou no botão Excluir, nº: '+idContato);
    this.dataSource.pop();
    this.table.renderRows();
  }
}
