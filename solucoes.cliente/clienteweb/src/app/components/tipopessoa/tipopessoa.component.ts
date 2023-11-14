import { Component, NgModule, OnInit } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { enums } from 'src/app/services/enum.service';

@Component({
  selector: 'tipopessoa',
  templateUrl: './tipopessoa.component.html',
  styleUrls: ['./tipopessoa.component.scss']
})
export class TipoPessoaComponent implements OnInit {

constructor(public menuService: MenuService,
  public ngSelectModule: NgSelectModule,
  public formsModule: FormsModule,
  public commonModule: CommonModule,
  public enumTipolPessoa: enums) {
}

selectTipo: number;
tipoPessoasEnum =[
  {idTipoPessoa: 1, nameTipoPessoa: 'Pessoa Fisica'},
  {idTipoPessoa: 2, nameTipoPessoa: 'Pessoa Jurídica'}
];
tipoPessoaOptions: { value: number; label: string }[] = [];

  ngOnInit(): void {
    this.tipoPessoaOptions = this.enumTipolPessoa.getTipoPessoaOptions();
  }

}
