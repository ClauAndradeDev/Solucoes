using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class TicketDto: CadastroModeloDto
    {
        public string? Titulo { get; set; }
        public int? NumeroSequencial { get; set; } //AAAAmmDD+Id
        public TipoChamadoEnum TipoChamado { get; set; }
        public bool Origem { get; set; }
        public DateTime DataAbertura { get; set; }

        public virtual EmpresaDto? Empresa { get; set; } //Objeto simples, mas estava como array
        public virtual PlataformaDto? Plataforma { get; set; } //Objeto simples, mas estava como array
        public virtual TicketRelacionamentoDto? TicketRelacionamento { get; set; }

    }
}
