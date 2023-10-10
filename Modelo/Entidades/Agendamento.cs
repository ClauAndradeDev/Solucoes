using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Agendamento : BaseModeloCadastro
    {
        public int IdChamado { get; set; }
        public string? Descricao { get; set; }
        public string? Conteudo { get; set; }
        public DateOnly DataPrevisaoInicializacao { get; set; }
        public DateOnly DataPrevisaoFinalizacao { get; set; }
        public DateOnly DataAgendamento { get; set; }
        public TimeOnly HoraInicial { get; set; }
        public TimeOnly HoraFinal { get; set; }
        public bool Realizado { get; set; }
    }
}
