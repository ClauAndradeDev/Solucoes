using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class TicketAgrupamentoDto : TicketDto
    {
        public int CodigoAgrupamento { get; set; }

    }
}
