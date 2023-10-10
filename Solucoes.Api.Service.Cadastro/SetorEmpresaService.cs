using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class SetorEmpresaService : CrudServices<SetorEmpresa, SetorEmpresaDto>
    {
        public LogMovimentacaoRepositorio LogMovimentacaoRepositorio { get; set; }
        public SetorEmpresaService(SetorEmpresaRepositorio setornEmpresaRepositorio
            , LogMovimentacaoRepositorio logMovimentacaoRepositorio
            , Mapper.Mapper mapper) :
            base(setornEmpresaRepositorio, mapper)
        {
            LogMovimentacaoRepositorio = logMovimentacaoRepositorio;
        }

        public override async Task<SetorEmpresaDto> Insert(SetorEmpresaDto setor)
        {
            var setorDto = await base.Insert(setor);
            var setorModel = await base.ReturnModel(setorDto.Codigo);

            await InserirLogMovimentacao(setorModel, 1);

            var result = await base.FindByCodigo(setorModel.Id);

            return result;
        }

        public override async Task<SetorEmpresaDto> Update(int id, SetorEmpresaDto setor)
        {
            var setorDto = await base.Update(id, setor);
            var setorModel = await base.ReturnModel(setorDto.Codigo);

            await InserirLogMovimentacao(setorModel, 2);

            var result = await base.FindByCodigo(setorModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var setorDto = await base.FindByCodigo(id);
            var setorModel = await base.ReturnModel(setorDto.Codigo);

            await InserirLogMovimentacao(setorModel, 3);

            await base.Delete(setorDto.Codigo);
        }

        public async Task InserirLogMovimentacao(SetorEmpresa setor, int situacao)
        {
            //registrar logMovimentação
            var logMov = new LogMovimentacao();
            var tabela = "SetorEmpresa";
            var conteudo = setor;

            logMov.DataAlteracao = DateTime.Today;
            logMov.Movimentacao = (Modelo.Enums.SituacaoRegistroEnum)situacao;
            logMov.Tabela = tabela;
            logMov.Conteudo = (System.Text.Json.Nodes.JsonArray?)Helpers.ConverterObjectJson(conteudo);

            await LogMovimentacaoRepositorio.Add(logMov);
        }
    }
}
