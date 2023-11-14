import { PerfilPessoaEnum } from 'src/app/models/perfilPessoaEnum.model';
//import { SelecionarEmpresaModule } from './../../components/selecionar-empresa/selecionar-empresa.module';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pessoa } from 'src/app/models/pessoa.model';
import { SelectModel } from 'src/app/models/selectModel';
import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { enums } from 'src/app/services/enum.service';
import { PessoaService } from 'src/app/services/pessoa.service';
import { EmpresaService } from 'src/app/services/empresa.service';
import { PessoaModule } from './pessoa.module';
import { PerfilPessoaModule } from 'src/app/components/perfilpessoa/perfilpessoa.module';
import { SelecionarEmpresaModule } from 'src/app/components/selecionar-empresa/selecionar-empresa.module';


@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss'],
})

export class PessoaComponent implements OnInit {
  constructor(
    public menuService: MenuService,
    public authService: AuthService,
    public activedRoute: ActivatedRoute,
    public ngSelectModule: NgSelectModule,
    public formsModule: FormsModule,
    public enumPerfilPessoa: enums,
    public enumTipoPessoa: enums,
    public enumTipoEndereco: enums,
    public enumTipoContato: enums,
    public pessoaService: PessoaService,
    public pessoaModule: PessoaModule,
    public empresaService: EmpresaService,
    private router: Router,
    public selecionarEmpresaModule: SelecionarEmpresaModule,
    public perfilPessoaModule: PerfilPessoaModule,

  ) {}

  panelOpenState = false;

  tipoTela: number = 1;
  tableListPessoa: Array<Pessoa>;

  selectTipo: number;
  tipoPessoasEnum =[
    {idTipoPessoa: 1, nameTipoPessoa: 'Pessoa Fisica'},
    {idTipoPessoa: 2, nameTipoPessoa: 'Pessoa Jurídica'}
  ];

  selectTipoEndereco: number;
  tipoEnderecoEnum=[
    {idTipoEndereco: 1, nameTipoEndereco: 'Cobrança'},
    {idTipoEndereco: 2, nameTipoEndereco: 'Comercial'},
    {idTipoEndereco: 3, nameTipoEndereco: 'Entrega'},
    {idTipoEndereco: 4, nameTipoEndereco: 'Residencial'}
  ];

  selectTipoContato: number;
  tipoContatoEnum=[
    {idTipoContato: 1, nameTipoContato: 'Comercial'},
    {idTipoContato: 2, nameTipoContato: 'Preferencial'},
    {idTipoContato: 3, nameTipoContato: 'Residencial'}
  ];

  tipoPessoaOptions: { value: number; label: string }[] = [];
  tipoEnderecoOptions: { value: number; label: string }[] = [];
  tipoContatoOptions:  { value: number; label: string }[] = [];

  ngOnInit() {
    this.menuService.menuSelecionado = 2;

    this.tipoPessoaOptions = this.enumTipoPessoa.getTipoPessoaOptions();
    this.tipoEnderecoOptions = this.enumTipoEndereco.getTipoEnderecoOptions();
    this.tipoContatoOptions = this.enumTipoContato.getTipoContatoOptions();

  }


}
