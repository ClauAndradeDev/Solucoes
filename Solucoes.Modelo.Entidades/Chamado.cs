using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("Chamado")]
    public class Chamado: CadastroModelo
    {
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public TipoChamadoEnum TipoChamado { get; set; }
        public DateTime DataAbertura { get; set; }

        [ForeignKey(nameof(EmpresaId))]
        public int EmpresaId { get; set; }
        //public virtual Empresa? Empresas { get; set; }

        [ForeignKey(nameof(PlataformaId))]
        public int PlataformaId { get; set; }
        public virtual Plataforma? Plataformas { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuarios { get; set; }

    }
}
