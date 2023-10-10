using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class ChamadoItem: MovimentacaoModelo
    {
       
        public DateTime DataRegistro { get; set; }
        public string? Conteudo { get; set; }

        [ForeignKey(nameof(IdChamado))]
        public int IdChamado { get; set; }
        public virtual Chamado? Chamados { get; set; }
    }
}
