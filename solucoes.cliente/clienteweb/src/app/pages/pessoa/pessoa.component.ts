import { Component, NgModule, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pessoa } from 'src/app/models/pessoa.model';
import { SelectModel } from 'src/app/models/selectModel';
import { AuthService } from 'src/app/services/auth.service';
import { MenuService } from 'src/app/services/menu.service';
import { $enum } from 'ts-enum-util';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { PerfilPessoaEnum } from 'src/app/models/perfilPessoaEnum.model';
import {enumPerfilPessoa} from 'src/app/services/enum.service';

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
    public enumPerfilPessoa: enumPerfilPessoa,
    private router: Router
  ) {}

  tipoTela: number = 1;
  tableListPessoa: Array<Pessoa>;

  /*Paginação */
  page: number = 1;
  config: any;
  paginacao: boolean = true;
  itemsPorPagina: number = 10;

  perfilPessoaOptions: { value: number; label: string }[] = [];

  ngOnInit() {
    this.menuService.menuSelecionado = 2;

    this.perfilPessoaOptions = this.enumPerfilPessoa.getPerfilPessoaOptions();
  }

  // configpag() {
  //   this.id = this.gerarIdParaConfigDePaginacao();

  //   this.config = {
  //     id: this.id,
  //     currentPage: this.page,
  //     itemsPerPage: this.itemsPorPagina,
  //   };
  // }

  gerarIdParaConfigDePaginacao() {
    var result = '';
    var characters =
      'ABCDEFGHIJKLMNOPQRSTUVXZabcdefghijklmnopqrstuvxz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 0; i++) {
      result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
  }

  // cadastro() {
  //   this.tipoTela = 2;
  //   this.sistemaForm.reset();
  // }

  mudarItensPorPage() {
    this.page = 1;
    this.config.currentPage = this.page;
    this.config.itemsPerPage = this.itemsPorPagina;
  }

  mudarPage(event: any) {
    this.page = event;
    this.config.currentPage = this.page;
  }

  // Redirecionar() {
  //   this.router.navigate(['pessoa']);
  // }

  // getPerfilPessoa(perfilPessoaEnum: PerfilPessoaEnum) {
  //   $enum.mapValue(perfilPessoaEnum).with({
  //     1: 'Cliente',
  //     2: 'Fornecedor',
  //     3: 'Funcionario',
  //     4: 'Transportadora',
  //   });
  // }
}
