using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class ChamadoDto: CadastroModeloDto
    {
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public TipoChamadoEnum TipoChamado { get; set; }
        public DateTime DataAbertura { get; set; }

        public virtual EmpresaDto[]? Empresas { get; set; }
        public virtual PlataformaDto[]? Plataformas { get; set; }
        public virtual UsuarioDto[]? Usuarios { get; set;}
    }
}
