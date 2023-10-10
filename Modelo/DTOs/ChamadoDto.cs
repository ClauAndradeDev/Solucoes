using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTOs
{
    public class ChamadoDto: BaseModeloCadastroDto
    {
        public int CodEmpresa { get; set; }
        public int CodUsuario { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public SituacaoChamadoEnum SituacaoChamado { get; set; }
        public TipoChamadoEnum TipoChamado { get; set; }
    }
}
