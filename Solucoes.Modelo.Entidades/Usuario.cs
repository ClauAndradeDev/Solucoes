using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Usuario : CadastroModelo
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoa { set; get; }
        public virtual ICollection<TicketAcao>? TicketAcoes { get; set; }
    }
}
