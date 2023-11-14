import { Component, NgModule, OnInit } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { enums } from 'src/app/services/enum.service';

@Component({
  selector: 'perfilpessoa',
  templateUrl: './perfilpessoa.component.html',
  styleUrls: ['./perfilpessoa.component.scss']
})

export class PerfilPessoaComponent implements OnInit {

  constructor(public menuSerivce:MenuService,
    public ngSelectModule: NgSelectModule,
    public formsModule: FormsModule,
    public commonModule: CommonModule,
    public enumPerfilPessoa: enums) {
  }

  selectPerfil: number;
  perfilEnum =[
    {idPerfil: 1, namePerfil: 'Cliente'},
    {idPerfil: 2, namePerfil: 'Fornecedor'},
    {idPerfil: 3, namePerfil: 'Funcionario'},
    {idPerfil: 4, namePerfil: 'Transportadora'},
  ];

  perfilPessoaOptions: { value: number; label: string }[] = [];

  ngOnInit():void{
    this.perfilPessoaOptions = this.enumPerfilPessoa.getPerfilPessoaOptions();
  }


}


