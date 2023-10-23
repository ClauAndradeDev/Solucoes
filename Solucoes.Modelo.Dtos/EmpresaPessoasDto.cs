using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class EmpresaPessoasDto : CadastroModeloDto
    {
        public int CodEmpresa { get; set; }
        public int CodPessoa { get; set; }

        public EmpresaDto[]? Empresas { get; set; }
        public PessoaDto[]? Pessoas { get; set; }
    }
}
