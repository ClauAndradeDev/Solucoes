using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo
{
    public class MovimentacaoModelo: BaseModelo
    {
        public DateTime DataAlteracao { get; set; }
        public SituacaoMovimentacaoEnum Situacao { get; set; }
    }
}
