using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTOs
{
    public class BaseModeloAlteracaoDto: BaseModeloDto
    {
        public DateTime DataAlteracao { get; set; }
    }
}
