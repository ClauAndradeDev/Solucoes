using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Entidades
{
    [Table("LogMovimento")]
    public class LogMovimentacao: MovimentacaoModelo
    {
        public string? Tabela { get; set; }
        public JsonArray? Conteudo { get; set; }
        public SituacaoRegistroEnum Movimentacao { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public int IdUsuario { get; set; }
        public virtual Usuario? Usuarios { get; set; }

       public int Registro { get; set; }

    }
}
