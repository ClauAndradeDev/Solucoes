import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Service } from "./service";
import { Pessoa } from "../models/pessoa.model";


@Injectable({
    providedIn: 'root',
  })
  
  export class PessoaService extends Service {
    public override controllerName: string = "Auth";
  
    constructor(private httpClient: HttpClient) {
      super();
    }

    InserirPessoa(pessoa: Pessoa){
        return this.httpClient.post<Pessoa>(`${this.controllerUrl}/pessoa`,pessoa);
    }
    AlterarPessoa(idPessoa: number, pessoa:Pessoa)
    {
        return this.httpClient.put<Pessoa>(`${this.controllerUrl}/pessoa/${idPessoa}`,pessoa);
    }
    ExcluirPessoa(idPessoa:number){
        return this.httpClient.delete<Pessoa>(`${this.controllerUrl}/pessoa/${idPessoa}`);
    }
    ListarPessoas(){
        return this.httpClient.get<Pessoa>(`${this.controllerUrl}/pessoa`);
    }
    ListarPessoaPorCodigo(idPessoa: number)
    {
        return this.httpClient.get<Pessoa>(`${this.controllerUrl}/pessoa/${idPessoa}`);
    }

    /*Contatos*/
    AdicionarContato(idPessoa: number){

    }
    AlterarContato(){

    }
    ExcluirContato(){

    }

    /*Endereços */
    AdicionarEndereco(){

    }
    AlterarEndereco(){

    }
    ExcluirEndereco(){

    }

    /*Usuarios*/
    InserirUsuarioPessoa(){

    }
    AlterarUsuarioPessoa(){

    }

}