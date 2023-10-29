using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class TicketRelacionamento: BaseModelo
    {
        public int? TicketId { get; set; }
        public int? TicketAgrupamentoId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual TicketAgrupamento? TicketAgrupamento { get; set; }

    }
}
