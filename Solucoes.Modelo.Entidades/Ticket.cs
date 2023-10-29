using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    public class Ticket: CadastroModelo
    {
        public string? Titulo { get; set; }
        public int? NumeroSequencial { get; set; } //AAAAmmDD+Id
        public TipoChamadoEnum? TipoChamado { get; set; }
        public bool? Origem { get; set; }
        public DateTime? DataAbertura { get; set; }
        public int? EmpresaId { get; set; }
        public int? PlataformaId { get; set; }

        public virtual Empresa? Empresa { get; set; } //Objeto simples
        public virtual Plataforma? Plataforma { get; set; } //Objeto simples
        public virtual ICollection<TicketAgrupamento>? TicketAgrupamentos { get; set; }
        public virtual ICollection<TicketRelacionamento>? TicketRelacionamentos { get; set; }








        //[ForeignKey(nameof(PlataformaId))]
        //public int PlataformaId { get; set; }
        //public virtual Plataforma? Plataformas { get; set; }

        //[ForeignKey(nameof(UsuarioId))]
        //public int UsuarioId { get; set; }
        //public virtual Usuario? Usuarios { get; set; }

    }
}
