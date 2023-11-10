import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './services/authGuard.service';
import { LogoutComponent } from './pages/logout/logout.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'logout',
    component: LogoutComponent,
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./pages/dashboard/dashboard.module').then(
        (m) => m.DashboardModule
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'empresa',
    loadChildren: () =>
      import('./pages/empresa/empresa.module').then((m) => m.EmpresaModule),
  },
  {
    path: 'pessoa',
    loadChildren: () =>
      import('./pages/pessoa/pessoa.module').then((m) => m.PessoaModule),
  },
  {
    path: 'reuniao',
    loadChildren: () =>
      import('./pages/reuniao/reuniao.module').then((m) => m.ReuniaoModule),
  },
  {
    path: 'ticket',
    loadChildren: () =>
      import('./pages/ticket/ticket.module').then((m) => m.TicketModule),
  },
  {
    path: 'usuario',
    loadChildren: () =>
      import('./pages/usuario/usuario.module').then((m) => m.UsuarioModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
