
import { EnderecoComponent } from './../endereco/endereco.component';
import { TipoEnderecoEnum } from './../../models/tipoEnderecoEnum.models';
import { Component, ViewChild, OnInit, Input } from '@angular/core';
import {MatTable, MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import { enums } from 'src/app/services/enum.service';
import { MatExpansionPanel } from '@angular/material/expansion';
import { Endereco } from 'src/app/models/endereco.model';
import { EnderecoModule } from '../endereco/endereco.module';



export interface EnderecoElement{
  idEnderecoPessoa: number;
  tipoEnderecoPessoa: string;
  // logradouro: string;
   bairro: string;
  // cep: string;
  // cidade: string;
  // estado: string;
  edicao: boolean;
  exclusao: boolean;
}

const ELEMENT_ENDERECO: EnderecoElement[]=[
{idEnderecoPessoa: 1, tipoEnderecoPessoa: 'Comercial', bairro: 'Zona Sul', edicao: true, exclusao: true},
{idEnderecoPessoa: 2, tipoEnderecoPessoa: 'Residencial', bairro: 'Zona Sul', edicao: true, exclusao: true},
{idEnderecoPessoa: 3, tipoEnderecoPessoa: 'Entrega', bairro: 'Zona Sul', edicao: true, exclusao: true},
{idEnderecoPessoa: 4, tipoEnderecoPessoa: 'Cobrança', bairro: 'Zona Sul', edicao: true, exclusao: true},
{idEnderecoPessoa: 5, tipoEnderecoPessoa: 'Cobrança', bairro: 'Zona Norte', edicao: true, exclusao: true},
];


@Component({
  selector: 'gridview',
  templateUrl: './gridview.component.html',
  styleUrls: ['./gridview.component.scss'],

})

export class GridviewComponent implements OnInit {
  constructor( public enderecoModelule: EnderecoModule) {}

  ngOnInit(): void {

  }

  enderecoDataParaEnviar = {
    logradouro: '',
    bairro: '',
    selectTipoEndereco: 0,
    cidade: '',
    cep: '',
    estado:'',
    numero: 0
  };


  @Input() valor: string;

  @Input()
  set abrirPainelEndereco(valor:Boolean){
    if(valor === true)
    console.log('AbriPainelEndereço, gridview: ' + valor);


  }

  panelOpenState = false;

  displayedColumns: string[] = ['idEnderecoPessoa', 'tipoEnderecoPessoa','bairro','edicao','exclusao'];
  dataSource = [...ELEMENT_ENDERECO];



  @ViewChild(MatTable) table: MatTable<EnderecoElement>;

  @ViewChild(MatExpansionPanel, {static: true}) matExpansionPanelElement: MatExpansionPanel;

  addData() {
    const randomElementIndex = Math.floor(Math.random() * ELEMENT_ENDERECO.length);

    this.dataSource.push(ELEMENT_ENDERECO[randomElementIndex]);
    this.table.renderRows();
  }

  updateData(tipopessoa: number) {
    //deve expandir o painel de endereços
    console.log('Clicou no botão Edição, nº: '+tipopessoa);
    // const randomElementIndex = Math.floor(Math.random() * ELEMENT_ENDERECO.length);
    // this.dataSource.push(ELEMENT_ENDERECO[randomElementIndex]);
    // this.table.renderRows();
  }



  salvarEndereco(){

    let enderecoNovo = new Endereco();

    //separador de logradouro
    const logradouroArray = this.enderecoDataParaEnviar.logradouro.split(',');
    const rua = logradouroArray[0].trim(); // remove espaços em branco extras
    const numero = logradouroArray[1].trim(); // remov

    enderecoNovo.Logradouro = rua;
    enderecoNovo.Numero = numero;
    enderecoNovo.TipoEndereco = this.enderecoDataParaEnviar.selectTipoEndereco;
    enderecoNovo.Bairro = this.enderecoDataParaEnviar.bairro;
    enderecoNovo.CEP = this.enderecoDataParaEnviar.cep;
    enderecoNovo.Cidade = this.enderecoDataParaEnviar.cidade;
    enderecoNovo.Estado = this.enderecoDataParaEnviar.estado;



    // console.log('Novo Endereço: '+ enderecoNovo);

    // console.log('Logradouro :'+ enderecoNovo.Logradouro);
    // console.log('Logradouro :'+ enderecoNovo.Numero)
    // console.log('TipoEndereco: '+ enderecoNovo.TipoEndereco);
    // console.log('Bairro: '+ enderecoNovo.Bairro);
    // console.log('CEP: ' + enderecoNovo.CEP);
    // console.log('Cidade: ' + enderecoNovo.Cidade);
    // console.log('Estado: ' +  enderecoNovo.Estado);

    // console.log('JSON');
    // console.log(JSON.stringify(enderecoNovo, null, 2));

    //alert('Novo Endereço: ' + JSON.stringify(enderecoNovo, null, 2));
    this.enderecoModelule.salvarNovoEndereco(enderecoNovo);
    //irá enviar para componente Endereço, salvar o endereço e retornar os dados do endereço para preencher o gridview
  }


  removeData(tipopessoa: number) {
    console.log('Clicou no botão Excluir, nº: '+tipopessoa);
    this.dataSource.pop();
    this.table.renderRows();
  }
}
