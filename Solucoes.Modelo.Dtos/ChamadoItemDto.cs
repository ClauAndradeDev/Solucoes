using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ChamadoItemDto: MovimentacaoModeloDto
    {
        public DateTime DataRegistro { get; set; }
        public string? Conteudo { get; set; }

        public virtual ChamadoDto[]? Chamados { get; set; }
    }
}
