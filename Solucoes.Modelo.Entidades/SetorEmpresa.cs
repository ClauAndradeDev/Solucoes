using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("SetorEmpresa")]
    public class SetorEmpresa: CadastroModelo
    {
       
        public string? Descricao { get; set; }

        [ForeignKey(nameof(IdEmpresa))]
        public int IdEmpresa { get; set; }
        //public virtual Empresa? Empresas { get; set; }
    }
}
