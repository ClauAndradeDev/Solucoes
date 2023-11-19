import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PessoaComponent } from './pessoa.component';
import { PessoaRoutingModule } from './pessoa-routing.modules';
import { NavbarModule } from 'src/app/components/navbar/navbar.module';
import { SideBarModule } from 'src/app/components/sidebar/sidebar.module';
import { MenuService } from 'src/app/services/menu.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { MatExpansionModule  } from '@angular/material/expansion';
import { SelecionarEmpresaModule } from 'src/app/components/selecionar-empresa/selecionar-empresa.module';
import { PerfilPessoaModule } from 'src/app/components/perfilpessoa/perfilpessoa.module';
import { TipoPessoaModule } from 'src/app/components/tipopessoa/tipopessoa.module';
import { EnderecoModule } from 'src/app/components/endereco/endereco.module';
import { ContatoModule } from 'src/app/components/contato/contato.module';

import { MatListModule } from '@angular/material/list';
import { ListaSelecaoModule } from 'src/app/components/lista-selecao/lista-selecao.module';

import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { InformacaoPessoaModule } from 'src/app/components/informacao-pessoa/informacao-pessoa.module';
import { GridViewContatoModule } from 'src/app/components/gridviewContato/gridviewContato.module';
import { ContatoComponent } from 'src/app/components/contato/contato.component';
import { GridViewEnderecoModule } from 'src/app/components/gridview-endereco/gridview-endereco.module';


@NgModule({
  providers: [ContatoComponent],
  declarations: [PessoaComponent],
  imports: [
    CommonModule,
    PessoaRoutingModule,
    NavbarModule,
    FormsModule,
    SideBarModule,
    NgSelectModule,
    MatExpansionModule,
    SelecionarEmpresaModule,
    PerfilPessoaModule,
    TipoPessoaModule,
    EnderecoModule,
    ListaSelecaoModule,
    MatListModule,
    MatButtonModule,
    MatTableModule,
    GridViewEnderecoModule,
    MatFormFieldModule,
    InformacaoPessoaModule,
    GridViewContatoModule,
    ],
  exports: [CommonModule],

})
export class PessoaModule {}
