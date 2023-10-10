using Solucoes.Modelo.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solucoes.Modelo
{
    public class CadastroModelo : BaseModelo
    {
        public SituacaoCadastralEnum Situacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
