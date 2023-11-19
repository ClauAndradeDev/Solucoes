import { BehaviorSubject } from 'rxjs';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Endereco } from 'src/app/models/endereco.model';
import { enums } from 'src/app/services/enum.service';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { DadosEnderecosService } from 'src/app/services/dadosEnderecos.service';


@Component({
  selector: 'endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss']
})


export class EnderecoComponent implements OnInit {

  constructor(public enumTipoEndereco: enums,
    private dadosEnderecosService: DadosEnderecosService) { }

  @Input() enderecoData: any;
  @Output() salvarEndereco = new EventEmitter<any>();

  panelOpenState = false;

  selectTipoEndereco: number;
  tipoEnderecoEnum = [
    { idTipoEndereco: 1, nameTipoEndereco: 'Cobrança' },
    { idTipoEndereco: 2, nameTipoEndereco: 'Comercial' },
    { idTipoEndereco: 3, nameTipoEndereco: 'Entrega' },
    { idTipoEndereco: 4, nameTipoEndereco: 'Residencial' }
  ];

  tipoEnderecoOptions: { value: number; label: string }[] = [];

  idEnderecoPessoa: number;
  tipoEndereco: number;
  logradouro: string;
  bairro: string;
  cep: string;
  cidade: string;
  estado: string;

private dadosEndereco = new BehaviorSubject<Endereco>(null);
dadosEndereco$ = this.dadosEndereco.asObservable();



  ngOnInit(): void {
    this.enderecoData = {}
    this.tipoEnderecoOptions = this.enumTipoEndereco.getTipoEnderecoOptions();
    this.dadosEnderecosService.dadosEndereco$.subscribe((dados) => {
      if(dados){
       // console.log('ngOnInit, tipoEndereco: ' + dados.tipoEndereco);
        this.enderecoData.TipoEndereco = dados.tipoEndereco;
        this.enderecoData = dados;
        //console.log('endereco.components, ngOnInit(): ' + JSON.stringify(dados, null, 2));
      }
    });

  }
  ngAfterViewInit(): void {
    this.dadosEnderecosService.dadosEndereco$.subscribe((dados) => {
      if (dados) {
        this.enderecoData.tipoEndereco = dados.tipoEndereco;
        this.enderecoData = dados;
      }
    });
  }

  onSalvarEndereco(){
    this.salvarEndereco.emit(this.enderecoData);
    console.log('onSalvarEndereco, endereco.component: '+JSON.stringify(this.enderecoData, null, 2));//está trazendo corretamente o Json enviado pelo gridviewContato
  }

  // dadosForm(){
  //   return this.enderecoForm.controls;
  // }

  // enderecoDataParaEnviar(){
  //   console.log('Logradouro informado: '+this.logradouro);
  // }

  // salvarEndereco() {
  //   var dados = this.dadosForm();
  //   let item = new Endereco();

  //   item.Logradouro = dados['logradouro'].value;
  //   console.log(item);

  // }



}


