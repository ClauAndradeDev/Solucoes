import { Component, OnInit } from '@angular/core';
import { enums } from 'src/app/services/enum.service';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.scss']
})
export class ContatoComponent implements OnInit {

  constructor(  public enumTipoContato: enums, menuService: MenuService) {}

  panelOpenState = false;

  selectTipoContato: number;
  tipoContatoEnum=[
    {idTipoContato: 1, nameTipoContato: 'Comercial'},
    {idTipoContato: 2, nameTipoContato: 'Preferencial'},
    {idTipoContato: 3, nameTipoContato: 'Residencial'}
  ];



  tipoContatoOptions:  { value: number; label: string }[] = [];



  ngOnInit(): void {
    this.tipoContatoOptions = this.enumTipoContato.getTipoContatoOptions();

  }
}
