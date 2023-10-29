using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ReuniaoDto: MovimentacaoModeloDto
    {
        public string? Descricao { get; set; }
        public DateTime DataPrevisaoInicio { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraAgendamentoInicial { get; set; }
        public DateTime HoraAgendamentoFinal { get; set; }

        public virtual TicketDto[]? Ticket {  get; set; }
        public virtual EmpresaDto[]? Empresa { get; set; }
    }
}
