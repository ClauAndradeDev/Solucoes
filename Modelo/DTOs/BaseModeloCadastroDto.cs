using Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTOs
{
    public class BaseModeloCadastroDto: BaseModeloDto
    {
        public DateOnly DataCadastro { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
