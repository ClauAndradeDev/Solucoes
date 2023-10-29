using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class ReuniaoAcao: BaseModelo
    {
        
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataPrevisaoRetorno { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public int ReuniaoId { get; set; }
        public int SetorId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Reuniao? Reuniao { get; set; }
        public virtual Setor? Setor { get; set; }
        public virtual Usuario? Usuario { get; set; }

    }
}
