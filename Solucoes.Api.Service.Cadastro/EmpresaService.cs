using AutoMapper.Execution;
using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class EmpresaService : CrudServices<Empresa, EmpresaDto>
    {
        public EnderecoRepositorio EnderecoRepositorio { get; set; }
        public SetorEmpresaRepositorio SetorEmpresaRepositorio { get; set; }
        public SetorEmpresaService SetorEmpresaService { get; set; }
        public EmpresaService(EmpresaRepositorio empresaRepositorio,
            EnderecoRepositorio enderecoRepositorio,
            SetorEmpresaRepositorio setorEmpresaRepositorio,
            SetorEmpresaService setorEmpresaService,
            Mapper.Mapper mapper) :
            base(empresaRepositorio, mapper)
        {
            EnderecoRepositorio = enderecoRepositorio;
            SetorEmpresaRepositorio = setorEmpresaRepositorio;
            SetorEmpresaService = setorEmpresaService;
        }

        public async Task<EmpresaDto> InserirEmpresa(EmpresaDto empresa)
        {

            empresa.DataCadastro = DateTime.Now;
            var empresaDto = await base.Insert(empresa);
            var empresaModel = await base.ReturnModel(empresaDto.Codigo);

            var result = await base.FindByCodigo(empresaModel.Id);

            return result;
        }

        public async Task<EmpresaDto> AlterarEmpresa(int codEmpresa, EmpresaDto empresa)
        {
            var empresaModel = await base.ReturnModel(codEmpresa);
            var empresaAlteradaModel = Mapper.Map<Empresa>(empresa);
            empresaAlteradaModel.DataCadastro = empresaModel.DataCadastro;


            var empresaAlterada = await Repositorio.Replace(empresaAlteradaModel.Id, empresaAlteradaModel);

            var result = await base.FindByCodigo(empresaAlterada.Id);

            return result;

            //var empresaModel = await Repositorio.FindById(codEmpresa);

            //var empresaAlteradaModel = Mapper.Map<Empresa>(empresa);
            //empresaAlteradaModel.DataCadastro = empresaModel.DataCadastro;


            //var empresaAlterada = await Repositorio.Replace(empresaAlteradaModel.Id, empresaAlteradaModel);

            //var result = Mapper.Map<EmpresaDto>(empresaAlterada);

            //return result;
        }

        public async Task<EmpresaDto> ExcluirEmpresa(int codEmpresa)
        {

            var empresaDto = await base.FindByCodigo(codEmpresa);

            var setoresExistentes = await SetorEmpresaService.BuscarSetorPorEmpresa(codEmpresa);
            var listaSetores = await SetorEmpresaService.All();

            if (setoresExistentes == null)
            {
                await base.Delete(empresaDto.Codigo);
            }
            else
            {

                    var setorModel = new Setor();
                foreach (var item in setoresExistentes.ToArray())
                {
                    foreach (var item1 in listaSetores)
                    {

                        if (item.Codigo == item1.Codigo)
                        {
                            item.Situacao = SituacaoCadastralEnum.Inativo;

                        }
                    }

                    var setor = await SetorEmpresaRepositorio.FindById(item.Codigo);

                    var setorModelModificado = Mapper.Map<Setor>(item);

                    setorModelModificado.EmpresaId = setor.EmpresaId;
                    setorModelModificado.Empresa = setor.Empresa;

                    await SetorEmpresaRepositorio.Replace(setorModelModificado.Id, setorModelModificado);
                }

                empresaDto.Situacao = SituacaoCadastralEnum.Inativo;
            }
            var empresaModel = Mapper.Map<Empresa>(empresaDto);
            await Repositorio.Replace(empresaModel.Id, empresaModel);

            return empresaDto;
        }

        /*VINCULAR EMPRESA - PESSOA*/
        //public async Task<EmpresaPessoasDto> VincularEmpresaPessoa(int codEmpresa, int codPessoa)
        //{
        //    var result = await 
        //}


        /*SETOR EMPRESA*/
        public async Task<SetorDto> AdicionarSetorEmpresa(int idEmpresa, SetorDto setor)
        {
            var result = await SetorEmpresaService.InsertSetorEmpresa(idEmpresa, setor);
            //var empresaModel = await Repositorio.FindById(idEmpresa);
            //var setorEmpresaModel = Mapper.Map<SetorEmpresa>(setor);
            //setorEmpresaModel.EmpresaId = empresaModel.Id;
            //setorEmpresaModel.DataCadastro = DateTime.Now;
            //setorEmpresaModel = await SetorEmpresaRepositorio.Add(setorEmpresaModel);

            //var result = Mapper.Map<SetorEmpresaDto>(setorEmpresaModel);

            return result;
        }

        public async Task<SetorDto> AlterarSetorEmpresa(int codEmpresa, SetorDto setor)
        {

            var result = await SetorEmpresaService.AlterarSetorEmpresa(codEmpresa, setor);
            //var empresaModel = await Repositorio.FindById(idEmpresa);
            //var setorEmpresaModel = Mapper.Map<SetorEmpresa>(setor);
            //setorEmpresaModel.EmpresaId = empresaModel.Id;
            //setorEmpresaModel.Descricao = setor.Descricao;
            //setorEmpresaModel.Situacao = setor.Situacao;

            //await SetorEmpresaRepositorio.Replace(setorEmpresaModel.Id, setorEmpresaModel);

            //var setorEmpDto = Mapper.Map<SetorEmpresaDto>(setorEmpresaModel);

            //var result =  await SetorEmpresaService.Update(setor.Codigo, SetorEmpDto);


            return result;

        }

        public async Task DeleteSetorEmpresa(int codEmpresa, int codSetor)
        {
            var empresaModel = await Repositorio.FindById(codEmpresa);
            //var setorModel = empresaModel.Setores.FirstOrDefault(st=>st.Id == codSetor);
            if (empresaModel != null)
            {
                await SetorEmpresaService.Delete(codSetor);
            }


            //var empresaModel = await Repositorio.FindById(codEmpresa);
            //var setorModel = await SetorEmpresaRepositorio.FindById(codSetor);

            //var setorModel = empresaModel.Setores
            //                    .FirstOrDefault(ss => ss.Id == codSetor);

            //var pessoaDto = await base.FindByCodigo(codEmpresa);

            //if (empresaModel is not null)
            //{
            //    await EnderecoRepositorio.Remove(codSetor);
            //}

        }

    }
}
