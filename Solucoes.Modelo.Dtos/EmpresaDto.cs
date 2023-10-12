using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class EmpresaDto: PessoaDto
    {
        public string? IEMunicipal { get; set; }
        //public int? CodPessoa { get; set; }
        public virtual PessoaDto[]? Pessoas { get; set; }
    }
}
