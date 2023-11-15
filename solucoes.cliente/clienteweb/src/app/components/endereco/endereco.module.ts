import { CommonModule } from '@angular/common';
import { EnderecoComponent } from './endereco.component';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgModule } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';


@NgModule({
  providers: [],
  declarations: [EnderecoComponent],
  imports: [CommonModule, FormsModule, NgSelectModule, MatExpansionModule],
  exports: [EnderecoComponent],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class EnderecoModule{

}
