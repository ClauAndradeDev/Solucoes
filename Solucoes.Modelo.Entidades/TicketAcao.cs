using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("TicketAcao")]
    public class TicketAcao: BaseModelo
    {
       
        public DateTime DataAcao { get; set; }
        public string? Conteudo { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }


        [ForeignKey(nameof(TicketId))]  
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public virtual Usuario? Usuario { get; set; }

    }
}
