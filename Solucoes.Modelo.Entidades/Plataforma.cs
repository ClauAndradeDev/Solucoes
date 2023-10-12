using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Plataforma")]
    public class Plataforma: CadastroModelo
    {
        public string? Descricao { get; set; }
    }
}
