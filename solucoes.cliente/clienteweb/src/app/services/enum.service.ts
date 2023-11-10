import { Injectable } from '@angular/core';
import { PerfilPessoaEnum } from '../models/perfilPessoaEnum.model';

@Injectable({
  providedIn: 'root',
})
export class enumPerfilPessoa {

  getPerfilPessoaOptions(): { value: number; label: string }[] {
    return Object.keys(PerfilPessoaEnum)
      .filter((key) => !isNaN(Number(key)))
      .map((key) => ({
        value: +key,
        label: PerfilPessoaEnum[key],
      }));
  }
}
