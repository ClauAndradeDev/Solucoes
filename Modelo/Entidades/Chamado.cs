using Modelo.Enums;

namespace Modelo.Entidades
{
    public class Chamado : BaseModeloCadastro
    {
        public int IdEmpresa { get; set; }
        public int IdUsuario { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public SituacaoChamadoEnum SituacaoChamado { get; set; }
        public TipoChamadoEnum TipoChamado { get; set; }


    }
}
