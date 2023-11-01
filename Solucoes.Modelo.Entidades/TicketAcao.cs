namespace Solucoes.Modelo.Entidades
{
    public class TicketAcao : BaseModelo
    {
        public int? TicketId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Conteudo { get; set; }
        public DateTime? DataAcao { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        //public int? NumSequencial { get; set; } alterar posterior
        /*
         * Verificar como percorrer a lista de TicketAcao existente, para reorganizar 
         * o NumeroSequencial que será apresentado na tela.
         */

        public virtual Ticket? Ticket { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
