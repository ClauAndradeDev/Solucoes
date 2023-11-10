using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class PessoaService : CrudServices<Pessoa, PessoaDto>
    {
        //public LogMovimentacaoRepositorio LogMovimentacaoRepositorio { get; set; }
        public EnderecoRepositorio EnderecoRepositorio { get; set; }
        public EnderecoService EnderecoService { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public ContatoRepositorio ContatoRepositorio { get; set; }
        public ContatoService ContatoService { get; set; }

        public UsuarioService UsuarioService { get; set; }
        public PessoaService(PessoaRepositorio pessoaRepositorio,
            //LogMovimentacaoRepositorio logMovimentacaoRepositorio,
            EmpresaRepositorio empresaRepositorio,
            ContatoRepositorio contatoRepositorio,
            ContatoService contatoService,
            EnderecoRepositorio enderecoRepositorio,
            EnderecoService enderecoService,
            UsuarioService usuarioService,
            Mapper.Mapper mapper) : base(pessoaRepositorio, mapper)
        {
            //LogMovimentacaoRepositorio = logMovimentacaoRepositorio;
            ContatoRepositorio = contatoRepositorio;
            ContatoService = contatoService;
            EnderecoRepositorio = enderecoRepositorio;
            EnderecoService = enderecoService;
            EmpresaRepositorio = empresaRepositorio;
            UsuarioService = usuarioService;
        }

        public async Task<PessoaDto> InserirPessoa(PessoaDto pessoa)
        {
            pessoa.DataCadastro = DateTime.Now;

            var pessoaDto = await base.Insert(pessoa);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(pessoaModel, 1, "Pessoa", pessoaModel.Id);

            var result = await base.FindByCodigo(pessoaModel.Id);

            return result;
        }
        public async Task<PessoaDto> AlterarPessoa(int codPessoa, PessoaDto pessoa)
        {
            var pessoaModel = new Pessoa();
            var result = new PessoaDto();
            if (codPessoa == pessoa.Codigo)
            {
                pessoaModel = await base.ReturnModel(codPessoa);
                var pessoaAlteradaModel = Mapper.Map<Pessoa>(pessoa);
                pessoaAlteradaModel.DataCadastro = pessoaModel.DataCadastro;

                var pessoaAlterada = await Repositorio.Replace(pessoaAlteradaModel.Id, pessoaAlteradaModel);
                result = await base.FindByCodigo(pessoaAlterada.Id);

            }
            ////await LogMovimentacaoService.InserirLogMov(pessoaModel, 2, "Pessoa", pessoaModel.Id);

            return result;
        }
        public async Task<PessoaDto> ExcluirPessoa(int codPessoa)
        {
            var pessoaDto = await base.FindByCodigo(codPessoa);

            //Endereço
            var enderecosExistente = await EnderecoService.BuscarEnderecoPorPessoa(codPessoa);
            var listaEnderecos = await EnderecoService.All();

            //Contato
            var contatoExistente = await ContatoService.BuscarContatoPorPessoa(codPessoa);
            var listaContatos = await ContatoService.All();

            if ((enderecosExistente.Count() == 0) && (contatoExistente.Count() == 0))
            {
                await base.Delete(codPessoa);
                return pessoaDto;
            }
            else
            {
                if (enderecosExistente != null)
                {
                    foreach (var item in enderecosExistente.ToArray())
                    {
                        foreach (var item1 in listaEnderecos)
                        {
                            if (item.Codigo == item1.Codigo)
                            {
                                item.Situacao = SituacaoCadastralEnum.Inativo;
                            }
                        }
                        var endereco = await EnderecoRepositorio.FindById(item.Codigo);
                        var enderecoModelModificado = Mapper.Map<Endereco>(item);

                        enderecoModelModificado.PessoaId = endereco.PessoaId;
                        enderecoModelModificado.Pessoa = endereco.Pessoa;

                        await EnderecoRepositorio.Replace(enderecoModelModificado.Id, enderecoModelModificado);
                    }
                }
                if (contatoExistente != null)
                {
                    foreach (var item in contatoExistente.ToArray())
                    {
                        foreach (var item1 in listaContatos)
                        {
                            if (item.Codigo == item1.Codigo)
                            {
                                item.Situacao = SituacaoCadastralEnum.Inativo;
                            }
                        }
                        var contato = await ContatoRepositorio.FindById(item.Codigo);
                        var contatoModelModificado = Mapper.Map<Contato>(item);

                        contatoModelModificado.PessoaId = contato.PessoaId;
                        contatoModelModificado.Pessoa = contato.Pessoa;

                        await ContatoRepositorio.Replace(contatoModelModificado.Id, contatoModelModificado);
                    }
                }

                pessoaDto.Situacao = SituacaoCadastralEnum.Inativo;

                var pessoaModel = Mapper.Map<Pessoa>(pessoaDto);
                await Repositorio.Replace(pessoaModel.Id, pessoaModel);

                return pessoaDto;
            }
        }

        /*ROTA CONTATO*/

        public async Task<ContatoDto> AdicionarContato(int codPessoa, ContatoDto contato)
        {
            return await ContatoService.InserirContatoPessoa(codPessoa, contato);
        }
        public async Task<ContatoDto> AlterarContato(int codPessoa, ContatoDto contato)
        {
            return await ContatoService.AlterarContatoPessoa(codPessoa, contato);
        }
        public async Task ExcluirContato(int codPessoa, int codContato)
        {
            await ContatoService.ExcluirContatoPessoa(codPessoa, codContato);
        }

        /*ROTA ENDEREÇO*/
        public async Task<EnderecoDto> AdicionarEndereco(int codPessoa, EnderecoDto endereco)
        {
            return await EnderecoService.InserirEnderecoPessoa(codPessoa, endereco);
        }
        public async Task<EnderecoDto> AlterarEndereco(int codPessoa, EnderecoDto endereco)
        {
            return await EnderecoService.AlterarEnderecoPessoa(codPessoa, endereco);
        }
        public async Task ExcluirEndereco(int codPessoa, int codEndereco)
        {
            await EnderecoService.ExcluirEnderecoPessoa(codPessoa, codEndereco);

        }

        /*ROTA USUARIO*/
        public async Task<UsuarioDto> InserirUsuarioPessoa(int codPessoa, UsuarioDto usuario)
        {
            return await UsuarioService.InserirUsuarioPessoa(codPessoa, usuario);
        }

        public async Task<UsuarioDto> AlterarUsuarioPessoa(int codPessoa, UsuarioDto usuario)
        {
            return await UsuarioService.AlterarUsuarioPessoa(codPessoa, usuario);
        }

        public async Task<UsuarioDto> AcessoUsuario(UsuarioDto usuario)
        {
            return await UsuarioService.AcessoUsuario(usuario);
        }

        //AcessoUsuarioLogar
        public async Task<UsuarioDto> AcessoUsuarioLogar(string login, string senha)
        {
            return await UsuarioService.AcessoUsuarioLogar(login, senha);
        }
        public async Task<UsuarioDto> AlterarSenhaUsuario(int codUsuario, UsuarioDto usuario)
        {
            return await UsuarioService.AlterarSenhaUsuario(codUsuario, usuario);
        }

        /*Rota Vincular Empresa a Pessoa*/

        //public async Task<EmpresaPessoasDto> VincularEmpresaPessoa(int codPessoa, int codEmpresa)
        //{
        //    var pessoaModel = await Repositorio.FindById(codPessoa);
        //    var empresaModel = await EmpresaRepositorio.FindById(codEmpresa);

        //    if ((pessoaModel != null) && (empresaModel != null))
        //    {

        //    }
        //}
    }
}
