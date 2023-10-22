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
            //empresa.DataCadastro = DateTime.Now;
            //var empresaDto = await base.Update(codEmpresa, empresa);
            
            var empresaModel = await base.ReturnModel(empresa.Codigo);
            empresaModel.NomeRazaoSocial = empresa.NomeRazaoSocial;
            empresaModel.SobreNomeFantasia = empresa.SobreNomeFantasia;
            empresaModel.IEMunicipal = empresa.IEMunicipal;
            empresaModel.RGIE = empresa.RGIE;
            empresaModel.DataAbertura = empresa.DataAbertura;
            empresaModel.Email = empresa.Email;
            empresaModel.Situacao = empresa.Situacao;
            empresaModel.Telefone = empresa.Telefone;
            empresaModel.TipoEmpresa = empresa.TipoEmpresa;
            empresaModel.WhatsApp = empresa.WhatsApp;

            var empresaAlterada = await Repositorio.Replace(empresaModel.Id, empresaModel);

            var result = await base.FindByCodigo(empresaAlterada.Id);

            return result;
        }

        public async Task<EmpresaDto> ExcluirEmpresa(int codEmpresa)
        {


            var empresaModel = await base.FindByCodigo(codEmpresa);
            
            
            var setoresExistentes = await SetorEmpresaService.BuscarSetorPorEmpresa(codEmpresa);
            var empresadto = Mapper.Map<EmpresaDto>(empresaModel);

            if (setoresExistentes == null)
            {
                
                //excluir
                await base.Delete(empresadto.Codigo);
              
            }
            //else
            //{
            //    //mensagem
            //}
            return empresadto;
        }


        /*ENDEREÇO EMPRESA*/
        public async Task<EnderecoDto> AdicionarEndereco(int idEmpresa, EnderecoDto endereco)
        {
            var empresaModel = await Repositorio.FindById(idEmpresa);
            var enderecoModel = Mapper.Map<Endereco>(endereco);
            enderecoModel.EmpresaId = empresaModel.Id;
            enderecoModel.DataCadastro = DateTime.Now;
            enderecoModel = await EnderecoRepositorio.Add(enderecoModel);

            var result = Mapper.Map<EnderecoDto>(enderecoModel);

            return result;
        }

        public async Task<EnderecoDto> AlterarEndereco(TipoEnderecoEnum tipoEndereco, EnderecoDto endereco)
        {
            //enderecoModel = Mapper.Map<Endereco>(endereco);
            var enderecoModel = await EnderecoRepositorio.FindById(endereco.Codigo);
            enderecoModel.Logradouro = endereco.Logradouro;
            enderecoModel.Numero = endereco.Numero;
            enderecoModel.Bairro = endereco.Bairro;
            enderecoModel.CEP = endereco.CEP;
            enderecoModel.Cidade = endereco.Cidade;
            enderecoModel.Estado = endereco.Estado;
            enderecoModel.TipoEndereco = tipoEndereco;

            enderecoModel = await EnderecoRepositorio.Replace(enderecoModel.Id, enderecoModel);

            var result = Mapper.Map<EnderecoDto>(enderecoModel);

            return result;
        }

        public async Task DeleteEndereco(int codEmpresa, int codEndereco)
        {
            var empresaModel = await Repositorio.FindById(codEmpresa);
            var enderecoModel = empresaModel.Enderecos
                                .FirstOrDefault(ee => ee.Id == codEndereco);

            var pessoaDto = await base.FindByCodigo(codEmpresa);

            if (empresaModel is not null)
            {
                await EnderecoRepositorio.Remove(codEndereco);
            }

        }

        /*SETOR EMPRESA*/
        public async Task<SetorEmpresaDto> AdicionarSetorEmpresa(int idEmpresa, SetorEmpresaDto setor)
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

        public async Task<SetorEmpresaDto> AlterarSetorEmpresa(int codEmpresa, SetorEmpresaDto setor)
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
