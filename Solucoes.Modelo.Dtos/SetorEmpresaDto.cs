using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class SetorEmpresaDto: CadastroModeloDto
    {
        //public int CodEmpresa { get; set; }
        public string? Descricao { get; set; }

        public virtual EmpresaDto[]? Empresas { get; set; }
    }
}
