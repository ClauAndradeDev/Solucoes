export class Pessoa {
  map(arg0: (p: any) => { id: any; name: any; }) {
    throw new Error('Method not implemented.');
  }
  Codigo: number;
  NomeRazaoSocial: string;
  SobreNomeFantasia: string;
  CPFCNPJ: string;
  RGIE: string;
  DataNascimento: Date;
  Email: string;
  Telefone: string;
  WhatsApp: boolean;
  TipoPessoa: number;
  PerfilPessoa: number;
  Acesso: number;
  Situacao: number;
  DataCadastro: Date;

  /*
  São necessário?
  Porque vou precisar na verdade da lista de Endereço, Contato, Usuario e Empresas
  */
  IdEmpresa: number;
  IdContato: number;
  IdUsuario: number;
}
