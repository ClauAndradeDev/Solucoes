using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class AgendamentoItem : BaseModeloAlteracao
    {
        public int IdAgendamento { get; set; }
        public string? Descricao { get; set; }
        public string? Conteudo { get; set; }
        public DateOnly DataAgendamento { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }
        public DateOnly DataRetorno { get; set; }
        public int IdSetorEmpresa { get; set; }
    }
}
