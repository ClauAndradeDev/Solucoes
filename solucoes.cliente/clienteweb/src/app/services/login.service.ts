import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environment";
import { Service } from "./service";
import { Login } from "../models/login.model";

@Injectable({
  providedIn: 'root',
})

export class LoginService extends Service {
  public override controllerName: string = "Auth";

  constructor(private httpClient: HttpClient) {
    super();
  }

  AcessoUsuario(user: string, password: string) {
    let usuario: Login = {
      usuario: user,
      senha: password
    };

    return this.httpClient.post<any>(`${this.controllerUrl}/login`, usuario);
  }

  // CarregarUsuario(){
  //   return this.httpClient.get<any>(`${this.controllerUrl}`);
  // }

  // DeslogarUsuario(){
  //   return this.httpClient.get<any>(`${this.controllerUrl}/logout`)
  // }

}
