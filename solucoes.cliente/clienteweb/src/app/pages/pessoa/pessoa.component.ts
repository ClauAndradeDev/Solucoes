import { EnderecoModule } from './../../components/endereco/endereco.module';
import { TipoPessoaModule } from './../../components/tipopessoa/tipopessoa.module';
import { Component, Input, OnInit } from '@angular/core';
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
    public tipoPessoaModule: TipoPessoaModule,
    public enderecoModule: EnderecoModule,

  ) { }

  panelOpenState = false;



  tipoTela: number = 1;
  tableListPessoa: Array<Pessoa>;
  codigo: number;
  razaosocial: string;
  nomefantasia: string;
  cpfcnpj: string;
  rgie: string;
  datanascimento: Date;
  email: string;
  telefone: string;
  whatsapp: boolean;
  perfilPessoa: number;
  tipoPerfil: number;
  empresa: number;

  perfilDataParaEnviar = {
    selectPerfil: 0
  };

  tipoPessoaParaEnviar = {
    selectTipoPessoa: 0
  };

  empresaDataParaEnviar = {
    selectEmpresa: 0
  };

  informacaoDataParaEnviar = {
    selectPerfil: 0,
    selectTipoPessoa: 0,
    selectEmpresa: 0
  }

  // contatoDataParaEnviar={
  //   selectTipoContato: 0,
  //   contatoNome: '',
  //   telefoneContato:'',
  //   emailContato:''
  // }


  @Input()
  set valor(valor: string) {
    if (valor === 'Vue' || valor == 'React')
      valor = 'Endereços';
    this.valor = valor;
  }

  ngOnInit() {
    this.menuService.menuSelecionado = 2;

  }

  salvarPessoa() {
    //debugger;
    let pessoaNovo = new Pessoa();

    pessoaNovo.Codigo = this.codigo;
    console.log('Pessoa Código: ' + pessoaNovo.Codigo);
    pessoaNovo.NomeRazaoSocial = this.razaosocial;
    pessoaNovo.SobreNomeFantasia = this.nomefantasia;
    pessoaNovo.CPFCNPJ = this.cpfcnpj;
    pessoaNovo.RGIE = this.rgie;
    pessoaNovo.Email=this.email;
    pessoaNovo.DataNascimento = this.datanascimento;
    pessoaNovo.Telefone = this.telefone;
    pessoaNovo.WhatsApp = this.whatsapp;
    pessoaNovo.PerfilPessoa = this.informacaoDataParaEnviar.selectPerfil;
    pessoaNovo.TipoPessoa = this.informacaoDataParaEnviar.selectTipoPessoa;
    //pessoaNovo.IdEmpresa = this.informacaoDataParaEnviar.selectEmpresa;
    pessoaNovo.Acesso = 1;
    if (pessoaNovo.Codigo == undefined) {
      console.log('Nova Pessoa');
      this.pessoaService.InserirPessoa(pessoaNovo);
    } else {
      console.log('Alterando Pessoa');
      this.pessoaService.InserirPessoa(pessoaNovo);
    }


    console.log('Nova Pessoa: ' + JSON.stringify(pessoaNovo, null, 2));
    //alert(JSON.stringify(pessoaNovo, null, 2));
  }

  // salvarContato(){
  //   let contatoNovo = new Contato();
  //   contatoNovo.Nome = this.contatoDataParaEnviar.contatoNome;
  //   contatoNovo.Telefone = this.contatoDataParaEnviar.telefoneContato;
  //   contatoNovo.Email = this.contatoDataParaEnviar.emailContato;
  //   contatoNovo.TipoContato = this.contatoDataParaEnviar.selectContato;


  //   console.log('Novo Contato: ' + JSON.stringify(contatoNovo, null, 2));
  //   alert(JSON.stringify(contatoNovo, null, 2));
  // }


}
