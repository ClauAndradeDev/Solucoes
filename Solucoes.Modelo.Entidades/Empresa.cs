using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Empresa")]
    public class Empresa: Pessoa
    {
        //quais outras informações necessárias para essa solicitação
        public string? IEMunicipal { get; set; }

        [ForeignKey(nameof(IdPessoa))]
        public int? IdPessoa { get; set; }
        //public virtual Pessoa? Pessoa { get; set; }

    }
}
