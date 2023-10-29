using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ReuniaoAcaoDto: BaseModeloDto
    {
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataPrevisaoRetorno { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }

        public virtual ReuniaoDto[]? Reuniao { get; set; }
        public virtual SetorDto[]? Setor { get; set; }
        public virtual UsuarioDto[]? Usuario { get; set; }
    }
}
