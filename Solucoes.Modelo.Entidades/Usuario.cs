using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Usuario: CadastroModelo
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        
        [ForeignKey(nameof(IdPessoa))]
        public int? IdPessoa { get; set; }
        public virtual Pessoa? Pessoas { set; get; }
    }
}
