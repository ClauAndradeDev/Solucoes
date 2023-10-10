using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Reuniao: MovimentacaoModelo
    {
        public string? Descricao { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataPrevisaoInicio { get; set; }
        public DateTime DataPrevisaoFim { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraAgendamento { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public DateTime DataRetorno { get; set; }

        [ForeignKey(nameof(IdChamado))]
        public int? IdChamado { get; set; }
        public virtual Chamado? Chamados { get; set; }

        [ForeignKey(nameof(IdEmpresa))]
        public int? IdEmpresa { get; set; }
        public virtual Empresa? Empresas { get; set; }   
        

    }
}
