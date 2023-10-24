using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class SetorDto: CadastroModeloDto
    {
        public string? Descricao { get; set; }

        public  EmpresaDto? Empresa { get; set; }
        
    }
}
