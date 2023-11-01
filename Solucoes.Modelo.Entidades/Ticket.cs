using Solucoes.Modelo.Enums;

namespace Solucoes.Modelo.Entidades
{
    public class Ticket : MovimentacaoModelo
    {
        public string? Titulo { get; set; }
        public int? NumeroSequencial { get; set; } //AAAAmmDD+Id
        public TipoChamadoEnum? TipoChamado { get; set; }
        public bool? Origem { get; set; }
        public DateTime? DataAbertura { get; set; }
        public int? EmpresaId { get; set; }
        public int? PlataformaId { get; set; }

        public virtual Empresa? Empresa { get; set; } //Objeto simples
        public virtual Plataforma? Plataforma { get; set; } //Objeto simples

        //public virtual ICollection<TicketAgrupamento>? TicketAgrupamentos { get; set; }
        //public virtual ICollection<TicketRelacionamento>? TicketRelacionamentos { get; set; }
        public virtual ICollection<TicketAcao>? TicketAcoes { get; set; }


    }
}
