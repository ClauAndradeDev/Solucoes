using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Solucoes.Modelo.Entidades
{
    public class PessoaEmpresa : CadastroModelo
    {
        public int EmpresaId { get; set; }
        public int PessoaId { get; set; }
        public virtual Empresa? Empresa { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

        /* Permissões de acesso*/

    }
}
