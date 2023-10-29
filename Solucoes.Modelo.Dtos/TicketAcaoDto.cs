using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class TicketAcaoDto: BaseModeloDto
    {
        public DateTime DataAcao { get; set; }
        public string? Conteudo { get; set; }

        public virtual TicketDto? Ticket { get; set; }
        public virtual UsuarioDto? Usuario { get; set; }
    }
}
