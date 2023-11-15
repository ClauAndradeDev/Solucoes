import { Component, OnInit } from '@angular/core';
import { enums } from 'src/app/services/enum.service';

@Component({
  selector: 'endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.scss']
})
export class EnderecoComponent implements OnInit{

  constructor(  public enumTipoEndereco: enums,) {}

  panelOpenState = false;

  selectTipoEndereco: number;

  tipoEnderecoEnum=[
    {idTipoEndereco: 1, nameTipoEndereco: 'Cobrança'},
    {idTipoEndereco: 2, nameTipoEndereco: 'Comercial'},
    {idTipoEndereco: 3, nameTipoEndereco: 'Entrega'},
    {idTipoEndereco: 4, nameTipoEndereco: 'Residencial'}
  ];

  tipoEnderecoOptions: { value: number; label: string }[] = [];

  ngOnInit(): void {
    this.tipoEnderecoOptions = this.enumTipoEndereco.getTipoEnderecoOptions();
  }



}


