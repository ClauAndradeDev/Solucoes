using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Reuniao")]
    public class Reuniao : MovimentacaoModelo
    {
        public string? Titulo { get; set; }
        public DateTime DataPrevisaoInicio { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraAgendamentoInicial { get; set; }
        public DateTime HoraAgendamentoFinal { get; set; }
        public int? EmpresaId { get; set; }
        public int? TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey(nameof(EmpresaId))]
        public virtual Empresa? Empresas { get; set; }


    }
}
