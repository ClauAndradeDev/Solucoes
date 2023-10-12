using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Endereco")]
    public class Endereco: CadastroModelo
    {
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public TipoEnderecoEnum TipoEndereco { get; set; }
        
        [ForeignKey(nameof(IdPessoa))]
        public int? IdPessoa { get; set; }
        //public virtual Pessoa? Pessoas { get; set; }
    }
}
