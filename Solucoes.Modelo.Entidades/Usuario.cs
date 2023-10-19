using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Usuario")]
    public class Usuario: CadastroModelo
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        
        [ForeignKey(nameof(PessoaId))]
        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoas { set; get; }
    }
}
