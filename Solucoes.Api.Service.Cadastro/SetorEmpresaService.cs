using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
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
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public SetorEmpresaService(SetorEmpresaRepositorio setornEmpresaRepositorio
            //, LogMovimentacaoService logMovimentacaoService
            , Mapper.Mapper mapper) :
            base(setornEmpresaRepositorio, mapper)
        {
          //  LogMovimentacaoService = logMovimentacaoService;
        }

        public override async Task<SetorEmpresaDto> Insert(SetorEmpresaDto setor)
        {
            setor.DataCadastro = DateTime.Now;
            var setorDto = await base.Insert(setor);
            var setorModel = await base.ReturnModel(setorDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(setorModel, 1, "Setor", setorModel.Id);

            var result = await base.FindByCodigo(setorModel.Id);

            return result;
        }

        public override async Task<SetorEmpresaDto> Update(int id, SetorEmpresaDto setor)
        {
            var setorDto = await base.Update(id, setor);
            var setorModel = await base.ReturnModel(setorDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(setorModel, 2, "Setor", setorModel.Id);

            var result = await base.FindByCodigo(setorModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var setorDto = await base.FindByCodigo(id);
            //var setorModel = await base.ReturnModel(setorDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(setorModel, 3, "Setor", setorModel.Id);

            await base.Delete(setorDto.Codigo);
        }
    }
}
