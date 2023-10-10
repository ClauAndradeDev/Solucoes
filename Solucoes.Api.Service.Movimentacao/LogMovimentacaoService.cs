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
        public async Task<LogMovimentacaoDto> InserirLogMov(Object objeto, int situacao, string tabela)
        {
            var logMov = new LogMovimentacaoDto();

            logMov.DataAlteracao = DateTime.Today;
            logMov.Movimentacao = (Modelo.Enums.SituacaoRegistroEnum)situacao;
            logMov.Tabela = tabela;
            logMov.Conteudo = (System.Text.Json.Nodes.JsonArray?)Helpers.ConverterObjectJson(objeto);

            var result = await base.Insert(logMov);

            return result;
        }
    }
}
