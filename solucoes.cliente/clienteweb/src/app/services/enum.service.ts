import { Injectable } from '@angular/core';
import { PerfilPessoaEnum } from '../models/perfilPessoaEnum.model';
import { TipoPessoaEnum } from '../models/tipoPessoaEnum.model';
import { TipoEnderecoEnum } from '../models/tipoEnderecoEnum.models';
import { TipoContatoEnum } from '../models/tipoContato.model';

@Injectable({
  providedIn: 'root',

})
export class enums {

  getPerfilPessoaOptions(): { value: number; label: string }[] {

    return Object.keys(PerfilPessoaEnum)
      .filter((key) => !isNaN(Number(key)))
      .map((key) => ({
        value: +key,
        label: PerfilPessoaEnum[key],
      }));
  }

  getTipoPessoaOptions(): { value: number; label: string }[] {
    return Object.keys(TipoPessoaEnum)
      .filter((key) => !isNaN(Number(key)))
      .map((key) => ({
        value: +key,
        label: TipoPessoaEnum[key],
      }));
  }

  getTipoEnderecoOptions(): { value: number; label: string }[] {
    return Object.keys(TipoEnderecoEnum)
      .filter((key) => !isNaN(Number(key)))
      .map((key) => ({
        value: +key,
        label: TipoEnderecoEnum[key],
      }));
  }

  getTipoContatoOptions(): { value: number; label: string }[] {
    return Object.keys(TipoContatoEnum)
      .filter((key) => !isNaN(Number(key)))
      .map((key) => ({
        value: +key,
        label: TipoContatoEnum[key],
      }));
  }
}
