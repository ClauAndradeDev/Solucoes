using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ReuniaoItemDto: MovimentacaoModeloDto
    {
        //public int CodReuniao { get; set; }
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataRealizada { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }

        public virtual ReuniaoDto[]? Reuniaos { get; set; }
    }
}
