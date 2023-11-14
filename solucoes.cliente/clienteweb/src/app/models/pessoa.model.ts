export class Pessoa {
  Id: number;
  NomeRazao: string;
  SobreNomeFantasia: string;
  cpfcnpj: string;
  rgie: string;
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
