using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Contato: CadastroModelo
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public TipoContatoEnum? TipoContato { get; set; }
        public int? PessoaId { get; set; }
        public virtual Pessoa? Pessoa { get; set; }
    }
}
