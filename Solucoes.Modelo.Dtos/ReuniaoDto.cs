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
        public string? Conteudo { get; set; }
        public DateTime DataPrevisaoInicio { get; set; }
        public DateTime DataPrevisaoFim { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HoraAgendamento { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public DateTime DataRetorno { get; set; }
        //public int? CodChamado { get; set; }
        //public int? CodEmpresa { get; set; }

        public virtual ChamadoDto[]? Chamados {  get; set; }
        public virtual EmpresaDto[]? Empresas { get; set; }
    }
}
