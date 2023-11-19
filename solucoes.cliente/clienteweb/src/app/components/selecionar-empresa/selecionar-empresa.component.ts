import { Component, Input, NgModule, OnInit } from '@angular/core';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { SelectModel } from 'src/app/models/selectModel';
import { EmpresaService } from 'src/app/services/empresa.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'selecionar-empresa',
  templateUrl: './selecionar-empresa.component.html',
  styleUrls: ['./selecionar-empresa.component.scss']
})

export class SelecionarEmpresaComponent implements OnInit{

constructor(public menuSerivce:MenuService,
  public ngSelectModule: NgSelectModule,
    public formsModule: FormsModule,
    public empresaService: EmpresaService,
    public commonModule: CommonModule) {
}

panelOpenState = false;
@Input() empresaData: any;

  ngOnInit(): void {
    this.CarregarEmpresas();
  }

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
}
