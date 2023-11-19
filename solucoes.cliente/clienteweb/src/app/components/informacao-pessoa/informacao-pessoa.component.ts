import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { SelectModel } from 'src/app/models/selectModel';
import { EmpresaService } from 'src/app/services/empresa.service';
import { enums } from 'src/app/services/enum.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'informacao-pessoa',
  templateUrl: './informacao-pessoa.component.html',
  styleUrls: ['./informacao-pessoa.component.scss']
})
export class InformacaoPessoaComponent implements OnInit {

  constructor(public menuService: MenuService,
    public ngSelectModule: NgSelectModule,
    public formsModule: FormsModule,
    public commonModule: CommonModule,
    public empresaService: EmpresaService,
    public enumTipolPessoa: enums,
    public enumPerfilPessoa: enums) {
  }

  panelOpenState = false;


  selectTipo: number;
  tipoPessoasEnum = [
    { idTipoPessoa: 1, nameTipoPessoa: 'Pessoa Fisica' },
    { idTipoPessoa: 2, nameTipoPessoa: 'Pessoa Jurídica' }
  ];

  tipoPessoaOptions: { value: number; label: string }[] = [];

  @Input() informacaoData: any;


  selectPerfil: number;
  perfilEnum = [
    { idPerfil: 1, namePerfil: 'Cliente' },
    { idPerfil: 2, namePerfil: 'Fornecedor' },
    { idPerfil: 3, namePerfil: 'Funcionario' },
    { idPerfil: 4, namePerfil: 'Transportadora' },
  ];

  perfilPessoaOptions: { value: number; label: string }[] = [];

  listaEmpresas: SelectModel[] = [];
  selectEmpresa = new SelectModel();

  CarregarEmpresas(){
    this.empresaService.BuscarEmpresas().subscribe({
      next: (empresas)=>{
        //console.log(empresas);

        let ex = empresas.map(e => ({
          id: e.Codigo,
          name: e.NomeRazaoSocial
        }));

        //console.log(ex);
        this.listaEmpresas = ex;

      },
      error: (error)=>{
        console.log(error)
      }
    })
}

compararEmpresas(listaEmpresas: any):boolean{

  return true;
}

  ngOnInit(): void {
    this.tipoPessoaOptions = this.enumTipolPessoa.getTipoPessoaOptions();
    this.perfilPessoaOptions = this.enumPerfilPessoa.getPerfilPessoaOptions();
    this.CarregarEmpresas();
  }

}
