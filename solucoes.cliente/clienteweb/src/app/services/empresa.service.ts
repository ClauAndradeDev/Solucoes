import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Service } from "./service";
import { Empresa } from "../models/empresa.model";

@Injectable({
    providedIn: 'root',
  })

  export class EmpresaService extends Service {
    public override controllerName: string = "Empresa";

    constructor(private httpClient: HttpClient) {
      super();
    }

    InserirEmpresa(){

    }
    BuscarEmpresas()
    {
        return this.httpClient.get<Array<Empresa>>(`${this.controllerUrl}`);
    }
    BuscarEmpresaPorCodigo(){

    }
    AlterarEmpresa(){

    }
    ExcluirEmpresa(){

    }

    /*SETOR*/
    IncluirSetor(){

    }
    AlterarSetor(){

    }
    ExcluirSetorEmpresa(){

    }
    BuscarSetorPorEmpresa(){

    }

    /*PLATAFORMA*/
    IncluirPlataforma(){

    }
    AlterarPlataforma(){

    }
    ExcluirPlataformaEmpresa(){

    }
    BuscarPlataformaPorEmpresa(){

    }

    /*PESSOA*/
    VincularPessoaEmpresa(){

    }
    RemoverVinculoPessoaEmpresa(){

    }
}
