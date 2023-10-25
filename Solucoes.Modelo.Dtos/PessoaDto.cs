using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class PessoaDto: CadastroModeloDto
    {
        public string? NomeRazaoSocial { get; set; }
        public string? SobreNomeFantasia { get; set; }
        public string? CPFCNPJ { get; set; }
        public string? RGIE { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public bool WhatsApp { get; set; }
        public TipoPessoaEnumcs TipoPessoa { get; set; }
        public PerfilPessoaEnum PerfilPessoa { get; set; }
        public AcessoEnum Acesso { get; set; }

        public EnderecoDto[]? Enderecos { get; set; }
        public ContatoDto[]? Contatos { get; set; }
    }
}
