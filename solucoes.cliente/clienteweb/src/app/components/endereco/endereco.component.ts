import { Component, Input, OnInit } from '@angular/core';
import { Endereco } from 'src/app/models/endereco.model';
import { enums } from 'src/app/services/enum.service';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
@Component({
  selector: 'endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss']
})
export class EnderecoComponent implements OnInit {

  constructor(public enumTipoEndereco: enums,
    public formBuilder: FormBuilder) { }

   enderecoForm: FormGroup;
  @Input() abrirPainelEndereco: boolean;
  @Input() enderecoData: any;

  selectTipoEndereco: number;

  tipoEnderecoEnum = [
    { idTipoEndereco: 1, nameTipoEndereco: 'Cobrança' },
    { idTipoEndereco: 2, nameTipoEndereco: 'Comercial' },
    { idTipoEndereco: 3, nameTipoEndereco: 'Entrega' },
    { idTipoEndereco: 4, nameTipoEndereco: 'Residencial' }
  ];

  tipoEnderecoOptions: { value: number; label: string }[] = [];

  tipoEndereco: number;
  logradouro: string;
  bairro: string;
  cep: string;
  cidade: string;
  estado: string;

dadosForm(){
  return this.enderecoForm.controls;
}

enderecoDataParaEnviar(){
  console.log('Logradouro informado: '+this.logradouro);
}
  ngOnInit(): void {
    this.tipoEnderecoOptions = this.enumTipoEndereco.getTipoEnderecoOptions();
    this.abrirPainelEndereco = false;


  }

  salvarEndereco() {
    var dados = this.dadosForm();
    let item = new Endereco();

    item.Logradouro = dados['logradouro'].value;
    console.log(item);

  }

}


