using Modelo.Enums;

namespace Modelo.Entidades
{
    public class BaseModeloCadastro : BaseModelo
    {
        public DateOnly DataCadastro { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
