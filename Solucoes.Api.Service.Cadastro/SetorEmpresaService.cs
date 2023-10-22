using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        public SetorEmpresaService(SetorEmpresaRepositorio setorEmpresaRepositorio,
                            //, LogMovimentacaoService logMovimentacaoService
                            EmpresaRepositorio empresaRepositorio
                            , Mapper.Mapper mapper) :
        base(setorEmpresaRepositorio, mapper)
        {
            EmpresaRepositorio = empresaRepositorio;
            //  LogMovimentacaoService = logMovimentacaoService;
        }

        public async Task<SetorEmpresaDto> InsertSetor(int codEmpresa, SetorEmpresaDto setor)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

            var setorModel = Mapper.Map<SetorEmpresa>(setor);

            if (empresaModel != null)
            {

                setorModel.DataCadastro = DateTime.Now;
                setorModel.EmpresaId = empresaModel.Id;

                await Repositorio.Add(setorModel);
                //await LogMovimentacaoService.InserirLogMov(setorModel, 1, "Setor", setorModel.Id);

            }
            var setorDto = Mapper.Map<SetorEmpresaDto>(setorModel);
            var result = await base.FindByCodigo(setor.Codigo);

            return result;
        }

        public async Task<SetorEmpresaDto> AlterarSetorEmpresa(int codEmpresa, SetorEmpresaDto setor)
        {
            var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

            var setorModel = await Repositorio.FindById(setor.Codigo);
            if ((empresaModel != null) && (empresaModel.Id == setorModel.EmpresaId))
            {
                setorModel.Descricao = setor.Descricao;
                setorModel.Situacao = setor.Situacao;

                await Repositorio.Replace(setorModel.Id, setorModel);
            }


            //var setorDto = base.ModelToDto(setorModel);
            // await base.Update(setorDto.Codigo, setorDto);

            //await LogMovimentacaoService.InserirLogMov(setorModel, 2, "Setor", setorModel.Id);

            var setorDto = Mapper.Map<SetorEmpresaDto>(setorModel);
            var result = await base.FindByCodigo(setorDto.Codigo);
            return result;
        }

        public override async Task Delete(int id)
        {
            var setorDto = await base.FindByCodigo(id);
            //var setorModel = await base.ReturnModel(setorDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(setorModel, 3, "Setor", setorModel.Id);

            await base.Delete(setorDto.Codigo);
        }

        public async Task<SetorEmpresaDto> BuscarSetorPorEmpresa(int codEmpresa)
        {
            var empresa = await EmpresaRepositorio.FindById(codEmpresa);
            var setores = empresa.Setores.ToArray();

            var result = Mapper.Map<SetorEmpresaDto>(setores);
            return result;
         
           

            //var setorDto = Mapper.Map<SetorEmpresaDto>(setorModel);
            //var result = await base.FindByCodigo(setorDto.Codigo);
            //return result;

        }
    }
}
