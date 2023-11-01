namespace Solucoes.Modelo.Dtos
{
    public class TicketAcaoDto : BaseModeloDto
    {
        public string? Conteudo { get; set; }
        public DateTime? DataAcao { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public UsuarioDto? Usuario { get; set; }
    }
}
