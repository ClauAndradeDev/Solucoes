using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Dtos
{
    public class LogMovimentacaoDto: MovimentacaoModeloDto
    {
        public string? Tabela { get; set; }
        public JsonArray? Conteudo { get; set; }
        public int Registro { get; set; }
        public SituacaoRegistroEnum Movimentacao { get; set; }
        public int CodUsuario { get; set; }
    }
}
