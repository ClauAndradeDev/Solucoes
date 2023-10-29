using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Setor: CadastroModelo
    {
        public string? Descricao { get; set; }
        public int? EmpresaId { get; set; }
        public virtual Empresa? Empresa { get; set; }
    }
}
