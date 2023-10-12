using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Movimentacao
{
    public class LogMovimentacaoService : CrudServices<LogMovimentacao, LogMovimentacaoDto>
    {
        public LogMovimentacaoService(LogMovimentacaoRepositorio logMovimentacaoRepositorio, 
            Mapper.Mapper mapper) : base(logMovimentacaoRepositorio, mapper)
        {
            

        }
        public async Task<LogMovimentacaoDto> InserirLogMov(Object objeto, int situacao, string tabela, int idTabela)
        {
            var logMov = new LogMovimentacaoDto
            {
                DataAlteracao = DateTime.Now,
                Movimentacao = (Modelo.Enums.SituacaoRegistroEnum)situacao,
                Tabela = tabela,
                Conteudo = (System.Text.Json.Nodes.JsonArray?)Helpers.ConverterObjectJson(objeto),
                Registro = idTabela,
                CodUsuario = 1
            };

            var result = await base.Insert(logMov);

            return result;
        }
    }
}
