import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Contato } from 'src/app/models/contato.model';
import { enums } from 'src/app/services/enum.service';
import { DadosContatoService } from 'src/app/services/dadosContato.service';



@Component({
  selector: 'contato',
  templateUrl: './contato.component.html',
  styleUrls: ['./contato.component.scss']
})
export class ContatoComponent implements OnInit {

  constructor(public enumTipoContato: enums,
    private dadosContatoService: DadosContatoService) { }

  @Input() contatoData: any;
  @Output() salvarContato = new EventEmitter<any>();

  panelOpenState = false;

  //dadosDoFormulario: any;

  tipoContato: number;
  tipoContatoEnum = [
    { idTipoContato: 1, nameTipoContato: 'Comercial' },
    { idTipoContato: 2, nameTipoContato: 'Preferencial' },
    { idTipoContato: 3, nameTipoContato: 'Residencial' }
  ];

  idContato: number;
  // selectTipoContato: 0,
 // tipoContato: number;
  contatoNome: string;
  contatoTelefone: string;
  contatoEmail: string;


  tipoContatoOptions: { value: number; label: string }[] = [];

  //@Output() contatoChange = new Contato();

  private dadosContato = new BehaviorSubject<Contato>(null);
  dadosContato$ = this.dadosContato.asObservable();

  ngOnInit(): void {
    this.contatoData = {};
    this.tipoContatoOptions = this.enumTipoContato.getTipoContatoOptions();
    this.dadosContatoService.dadosContato$.subscribe((dados) => {
      if(dados){
        this.contatoData.tipoContato = dados.tipoContato;
      this.contatoData = dados;
      }

    });

  }
  ngAfterViewInit(): void {
    this.dadosContatoService.dadosContato$.subscribe((dados) => {
      if (dados) {
        this.contatoData.tipoContato = dados.tipoContato;
        this.contatoData = dados;
      }
    });
  }

  onSalvarContato() {
    // Adicione validações ou manipulações necessárias nos dados antes de salvar
    this.salvarContato.emit(this.contatoData);
    console.log(this.contatoData);//está trazendo corretamente o Json enviado pelo gridviewContato
  }


}
