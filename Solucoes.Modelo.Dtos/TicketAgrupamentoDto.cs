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



//.ForMember(model => model.Id, opt => opt.MapFrom(dto => dto.CodigoAgrupamento))
//.ForMember(model => model.TicketId, opt => opt.MapFrom(dto => dto.Codigo))