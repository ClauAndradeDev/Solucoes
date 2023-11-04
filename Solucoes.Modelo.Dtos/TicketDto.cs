using Solucoes.Modelo.Enums;

namespace Solucoes.Modelo.Dtos
{
    public class TicketDto : MovimentacaoModeloDto
    {
        public string? Titulo { get; set; }
        public int? NumeroSequencial { get; set; } //AAAAmmDD+Id
        public TipoChamadoEnum? TipoChamado { get; set; }
        public bool? Origem { get; set; }
        public DateTime? DataAbertura { get; set; }

        public EmpresaDto? Empresa { get; set; } //Objeto simples, mas estava como array
        public PlataformaDto? Plataforma { get; set; } //Objeto simples, mas estava como array
       
        //public TicketRelacionamentoDto? TicketRelacionamento { get; set; }
        //public TicketAgrupamentoDto? TicketAgrupamento { get; set; }
        public virtual TicketAcaoDto[]? TicketAcoes { get; set;}
        public virtual ReuniaoDto[]? Reunioes { get; set; } 

    }
}
