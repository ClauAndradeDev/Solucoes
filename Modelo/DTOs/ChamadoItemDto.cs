namespace Modelo.DTOs
{
    public class ChamadoItemDto : BaseModeloAlteracaoDto
    {
        public int CodChamado { get; set; }
        public int CodUsuario { get; set; }
        public string? Descricao { get; set; }
        public TimeOnly HoraInicial { get; set; }
        public TimeOnly HoraFinal { get; set; }
    }
}
