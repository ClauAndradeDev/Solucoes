using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class TicketAgrupamento: BaseModelo
    {
        public int TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public virtual Ticket? Ticket { get; set; }

        public virtual ICollection<TicketRelacionamento>? TicketRelacionamentos { get; set; }    
    }
}
