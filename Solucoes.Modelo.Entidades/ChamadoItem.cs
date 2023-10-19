using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("ChamadoItem")]
    public class ChamadoItem: MovimentacaoModelo
    {
       
        public DateTime DataRegistro { get; set; }
        public string? Conteudo { get; set; }

        [ForeignKey(nameof(ChamadoId))]
        public int ChamadoId { get; set; }
        public virtual Chamado? Chamados { get; set; }
    }
}
