import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
// import { JwtHelperService } from '@auth0/angular-jwt';



@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private loginService: LoginService,
    private cookieService: CookieService,
    //private jwtHelper: JwtHelperService,
    private router: Router
  ) {}
  usuarioLogado: string;

  login(username: string, password: string) {
    this.usuarioLogado = username;
    return this.loginService.AcessoUsuario(username, password);

    //return this.http.post<any>('URL_DO_BACKEND/login', { username, password });
  }

  logout() {
    localStorage.removeItem('token');
    this.cookieService.delete('token');
    this.excluirCookie('token', this.usuarioLogado);
    this.router.navigate(['/login']);
  }

  isLoggedIn() {
    // Verifique se o token JWT ainda é válido
    const token = localStorage.getItem('token');
    this.definirCookie(token, this.usuarioLogado);
    return token; //!this.jwtHelper.isTokenExpired(token);
  }

  definirCookie(token: string, username: string) {
    this.cookieService.set(username, token);
  }

  // Método para obter um cookie
  obterCookie(token: string, username: string) {
    const valorDoCookie = this.cookieService.get(username);
    console.log(valorDoCookie);
  }

  // Método para verificar se um cookie existe
  verificarCookie(token: string, username: string) {
    const cookieExiste = this.cookieService.check(username);
    console.log(cookieExiste);
  }

  // Método para excluir um cookie
  excluirCookie(token: string, username: string) {
    this.cookieService.delete(username);
  }
}
