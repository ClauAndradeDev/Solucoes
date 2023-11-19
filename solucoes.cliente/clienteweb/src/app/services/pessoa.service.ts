import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Service } from "./service";
import { Pessoa } from "../models/pessoa.model";
import { Observable, catchError } from "rxjs";


@Injectable({
    providedIn: 'root',
  })

  export class PessoaService extends Service {
    public override controllerName: string = "Pessoa";

    constructor(private httpClient: HttpClient) {
      super();
    }

    InserirPessoa(pessoa: Pessoa){
      const headers = new HttpHeaders({
        'Content-Type': 'application/json'
      });
      return this.httpClient.post<Pessoa>(`${this.controllerUrl}`,pessoa, { headers: headers })
      .pipe(
        catchError(error => {
          console.error('Erro na solicitação de inclusão de pessoa:', error);
          throw error; // você pode decidir como lidar com o erro aqui
        })
      );
    }

    AlterarPessoa(idPessoa: number, pessoa:Pessoa)
    {
        return this.httpClient.put<Pessoa>(`${this.controllerUrl}/pessoa/${idPessoa}`,pessoa);
    }
    ExcluirPessoa(idPessoa:number){
        return this.httpClient.delete<Pessoa>(`${this.controllerUrl}/pessoa/${idPessoa}`);
    }

    ListarPessoas(){
        return this.httpClient.get<Array<Pessoa>>(`${this.controllerUrl}`);
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
