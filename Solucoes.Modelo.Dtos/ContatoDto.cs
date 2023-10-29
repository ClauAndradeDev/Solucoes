using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ContatoDto: CadastroModeloDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public TipoContatoEnum? TipoContato { get; set; }
        //public int CodPessoa { get; set; }
        public PessoaDto[]? Pessoas { get; set; }
    }
}
