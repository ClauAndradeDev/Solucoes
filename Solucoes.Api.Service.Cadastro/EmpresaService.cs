using AutoMapper.Execution;
using Microsoft.Identity.Client;
using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
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
        public SetorEmpresaRepositorio SetorEmpresaRepositorio { get; set; }
        public SetorEmpresaService SetorEmpresaService { get; set; }
        public PlataformaService PlataformaService { get; set; }
        public PlataformaRepositorio PlataformaRepositorio { get; set; }
        public EmpresaPessoaRepositorio EmpresaPessoaRepositorio { get; set; }
        public PessoaRepositorio PessoaRepositorio { get; set; }
        public EmpresaService(EmpresaRepositorio empresaRepositorio,
            SetorEmpresaRepositorio setorEmpresaRepositorio,
            SetorEmpresaService setorEmpresaService,
            PlataformaService plataformaService,
            PlataformaRepositorio plataformaRepositorio,
            EmpresaPessoaRepositorio empresaPessoaRepositorio,
            PessoaRepositorio pessoaRepositorio,
            Mapper.Mapper mapper) :
            base(empresaRepositorio, mapper)
        {
            SetorEmpresaRepositorio = setorEmpresaRepositorio;
            SetorEmpresaService = setorEmpresaService;
            PlataformaService = plataformaService;
            PlataformaRepositorio = plataformaRepositorio;
            EmpresaPessoaRepositorio = empresaPessoaRepositorio;
            PessoaRepositorio = pessoaRepositorio;
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
            //var empresaPessoas = empresaAlteradaModel.EmpresaPessoas.Where(ep => ep.Id == 0);

            //foreach (var ep in empresaPessoas)
            //{
            //    var pessoa = await PessoaRepositorio.FindById(ep.PessoaId);
            //    ep.PessoaId = ep.PessoaId;
            //    ep.EmpresaId = empresaAlteradaModel.Id;

            //    await EmpresaPessoaRepositorio.Add(ep);
            //}

            var result = await base.FindByCodigo(empresaAlterada.Id);

            return result;

        }
        public async Task<EmpresaDto> ExcluirEmpresa(int codEmpresa)
        {

            var empresaDto = await base.FindByCodigo(codEmpresa);

            var setoresExistentes = await SetorEmpresaService.BuscarSetorPorEmpresa(codEmpresa);
            var listaSetores = await SetorEmpresaService.All();

            var plataformaExistentes = await PlataformaService.BuscarPlataformaPorEmpresa(codEmpresa);
            var listaPlataforma = await PlataformaService.All();

            if ((setoresExistentes == null) && (plataformaExistentes == null))
            {
                await base.Delete(empresaDto.Codigo);
                return empresaDto;
            }
            else //if ((setoresExistentes != null) || (plataformaExistentes != null))
            {
                if (setoresExistentes != null)
                {
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
                }
                if (plataformaExistentes != null)
                {
                    foreach (var item in plataformaExistentes.ToArray())
                    {
                        foreach (var item1 in listaPlataforma)
                        {
                            if (item.Codigo == item1.Codigo)
                            {
                                item.Situacao = SituacaoCadastralEnum.Inativo;
                            }
                        }

                        var plataforma = await PlataformaRepositorio.FindById(item.Codigo);
                        var plataformaModificada = Mapper.Map<Plataforma>(item);

                        plataformaModificada.EmpresaId = plataforma.EmpresaId;
                        plataformaModificada.Empresa = plataforma.Empresa;

                        await PlataformaRepositorio.Replace(plataformaModificada.Id, plataformaModificada);
                    }
                }

                empresaDto.Situacao = SituacaoCadastralEnum.Inativo;
                var empresaModel = Mapper.Map<Empresa>(empresaDto);
                await Repositorio.Replace(empresaModel.Id, empresaModel);

                return empresaDto;
            }



        }


        /*SETOR EMPRESA*/
        public async Task<SetorDto> AdicionarSetorEmpresa(int idEmpresa, SetorDto setor)
        {
            var result = await SetorEmpresaService.InsertSetorEmpresa(idEmpresa, setor);

            return result;
        }
        public async Task<SetorDto> AlterarSetorEmpresa(int codEmpresa, SetorDto setor)
        {

            var result = await SetorEmpresaService.AlterarSetorEmpresa(codEmpresa, setor);

            return result;

        }
        public async Task DeleteSetorEmpresa(int codEmpresa, int codSetor)
        {
            await SetorEmpresaService.ExcluirSetorEmpresa(codEmpresa, codSetor);
            //var empresaModel = await Repositorio.FindById(codEmpresa);
            //var setorModel = await SetorEmpresaRepositorio.FindById(codSetor);
            ////var setorModel = empresaModel.Setores.FirstOrDefault(st=>st.Id == codSetor);
            ////futuramente se setor estirver vinculado com Reunião, precisa fazer validação
            //if ((empresaModel != null) && (setorModel != null))
            //{
            //    await SetorEmpresaService.Delete(codSetor);
            //}
        }

        /*PLATAFORMA EMPRESA*/
        public async Task<PlataformaDto> AdicionarPlataformaEmpresa(int codEmpresa, PlataformaDto plataforma)
        {
            var result = await PlataformaService.InsertPlataformaEmpresa(codEmpresa, plataforma);
            return result;
        }
        public async Task<PlataformaDto> AlterarPlataformaEmpresa(int codEmpresa, PlataformaDto plataforma)
        {
            var result = await PlataformaService.AlterarPlataformaEmpresa(codEmpresa, plataforma);
            return result;
        }
        public async Task DeletePlataformaEmpresa(int codEmpresa, int codPlataforma)
        {
            await PlataformaService.ExcluirPlataformaEmpresa(codPlataforma, codEmpresa);
        }

        /*VINCULO/DESVINCULO EMPRESA_PESSOA*/
        public async Task AdicionarPessoaEmpresa(int codEmpresa, int codPessoa)
        {
            var empresaModel = await Repositorio.FindById(codEmpresa);
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            
            var empresaPessoaModel = new EmpresaPessoa();
            var empresa = EmpresaPessoaRepositorio.All();

            if ((empresaModel != null) && (pessoaModel != null))
            {
                empresaPessoaModel.PessoaId = pessoaModel.Id;
                empresaPessoaModel.EmpresaId = empresaModel.Id;
                empresaPessoaModel.DataCadastro = DateTime.Now;
                await EmpresaPessoaRepositorio.Add(empresaPessoaModel);
            }
            
        }



        public async Task ExcluirPessoaEmpresa(int codEmpresa, int codPessoa)
        {
            var empresaModel = await Repositorio.FindById(codEmpresa);
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);

            var empresaPessoaBanco = empresaModel.EmpresaPessoas.FirstOrDefault(x => x.PessoaId == pessoaModel.Id);


            if ((empresaModel != null) && (pessoaModel != null))
            {
                await EmpresaPessoaRepositorio.Remove(empresaPessoaBanco.Id);
            }

        }
    }



}
