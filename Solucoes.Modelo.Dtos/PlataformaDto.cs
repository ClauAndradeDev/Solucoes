using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class PlataformaDto: CadastroModeloDto
    {
        public string? Descricao { get; set; }
        public virtual EmpresaDto? Empresa { get; set; } //virtual para gerar o banco, depois remover
    }
}
