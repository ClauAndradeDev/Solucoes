using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo
{
    public class CadastroModeloDto: BaseModeloDto
    {
        public SituacaoCadastralEnum Situacao { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
