using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("ReuniaoItem")]
    public class ReuniaoItem: MovimentacaoModelo
    {
        
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataRealizada { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }

        [ForeignKey(nameof(IdReuniao))]
        public int IdReuniao { get; set; }
        //public virtual Reuniao? Reuniaos { get; set; }

    }
}
