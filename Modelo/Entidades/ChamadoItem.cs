namespace Modelo.Entidades
{
    public class ChamadoItem : BaseModeloAlteracao
    {
        public int IdChamado { get; set; }
        public int IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public TimeOnly HoraInicial { get; set; }
        public TimeOnly HoraFinal { get; set; }
    }
}
