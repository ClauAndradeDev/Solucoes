using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Solucoes.Modelo.Entidades
{
    [Table("EmpresaPessoas")]
    public class EmpresaPessoas : CadastroModelo
    {
        [ForeignKey(nameof(EmpresaId))]
        public int EmpresaId { get; set; }
        public virtual Empresa? Empresas { get; set; }

        [ForeignKey(nameof(PessoaId))]
        public int PessoaId { get; set; }
        public virtual Pessoa? Pessoas { get; set; }

        /* Permissões de acesso*/

    }
}
