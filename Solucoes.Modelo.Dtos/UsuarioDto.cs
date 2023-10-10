using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class UsuarioDto: CadastroModeloDto
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        //public int? CodPessoa { get; set; }

        public virtual PessoaDto[]? Pessoas { get; set; }
    }
}
