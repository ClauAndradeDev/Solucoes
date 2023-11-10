import { Component } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  constructor(
    public formBuilder: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    private authService: AuthService,
    //public loginForm: FormGroup,
  ) {}

  loginForm: FormGroup;
  login: string = '';
  senha: string = '';

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      login: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    });
  }

  get dadosForm() {
    return this, this.loginForm.controls;
  }


  loginUser() {
  this.authService.login(this.dadosForm['login'].value, this.dadosForm['senha'].value).subscribe(
    (response) => {
      const token = response.token;
      localStorage.setItem('token', token);
      this.router.navigate(['/dashboard']);
    },
    (error) => {
      // Lida com erros de login
      alert('Verifique usuário e senha informados!');
      console.log(error), () => {};
    }
  );
}

// logoutUser(){
//   this.authService.logout();
// }




    //this.router.navigate(['/dashboard']);
    // this.loginService
    //   .AcessoUsuario(
    //     this.dadosForm['login'].value,
    //     this.dadosForm['senha'].value
    //   )
    //   .subscribe(
    //     (response: string) => {
    //       //console.log(response);
    //       this.router.navigate(['/dashboard']);
    //     },
    //     (erro) => {
    //       alert('Ocorreu um erro ' + erro);
    //       console.log(erro), () => {};
    //     }
    //   );
  //}
}
