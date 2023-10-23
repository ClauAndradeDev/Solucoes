using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class EnderecoDto: CadastroModeloDto
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }

        // public int? CodPessoa { get; set; }
        public PessoaDto[]? Pessoas { get; set; }
    }
}
