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
    public class PessoaService : CrudServices<Pessoa, PessoaDto>
    {
        //public LogMovimentacaoRepositorio LogMovimentacaoRepositorio { get; set; }
        public EnderecoRepositorio EnderecoRepositorio { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public ContatoRepositorio ContatoRepositorio { get; set; }
        public PessoaService(PessoaRepositorio pessoaRepositorio,
            //LogMovimentacaoRepositorio logMovimentacaoRepositorio,
            EmpresaRepositorio empresaRepositorio,
            ContatoRepositorio contatoRepositorio,
            EnderecoRepositorio enderecoRepositorio,
            Mapper.Mapper mapper) : base(pessoaRepositorio, mapper)
        {
            //LogMovimentacaoRepositorio = logMovimentacaoRepositorio;
            ContatoRepositorio = contatoRepositorio;
            EnderecoRepositorio = enderecoRepositorio;
            EmpresaRepositorio = empresaRepositorio;
        }

        public override async Task<PessoaDto> Insert(PessoaDto pessoa)
        {
            pessoa.DataCadastro = DateTime.Now;

            var pessoaDto = await base.Insert(pessoa);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            //if (pessoaModel.TipoEmpresa)
            //{
            //    var empresaModel = Mapper.Map<Empresa>(pessoa.Empresas);
            //    empresaModel.IdPessoa = pessoaModel.Id;
            //    var empresaDto = await EmpresaRepositorio.Add(empresaModel);
            //    var result1 = Mapper.Map<EmpresaDto>(empresaModel);
            //}
            //await LogMovimentacaoService.InserirLogMov(pessoaModel, 1, "Pessoa", pessoaModel.Id);

            var result = await base.FindByCodigo(pessoaModel.Id);


            return result;
        }

        public async Task<ContatoDto> AdicionarContato(int idPessoa, ContatoDto contato)
        {
            var contatoModel = Mapper.Map<Contato>(contato);
            contatoModel.PessoaId = idPessoa;
            //contatoModel.TipoContato = tipoContato;
            contatoModel = await ContatoRepositorio.Add(contatoModel);

            var result = Mapper.Map<ContatoDto>(contatoModel);

            return result;
        }

        public async Task<ContatoDto> AlteraContato(TipoContatoEnum tipoContato, ContatoDto contato)
        {
            var contatoModel = await ContatoRepositorio.FindById(contato.Codigo);
            contatoModel.TipoContato = tipoContato;
            contatoModel.Nome = contato.Nome;
            contatoModel.Situacao = contato.Situacao;
            contatoModel.Email = contato.Email;
            contatoModel.Telefone = contato.Telefone;

            contatoModel = await ContatoRepositorio.Replace(contatoModel.Id, contatoModel);
            var result = Mapper.Map<ContatoDto>(contatoModel);

            return result;
        }

        public async Task<EnderecoDto> AdicionarEndereco(int idPessoa, EnderecoDto endereco)
        {
            //var pessoaModel = await Repositorio.FindById(idPessoa);

            var enderecoModel = Mapper.Map<Endereco>(endereco);
            enderecoModel.PessoaId = idPessoa;
            enderecoModel = await EnderecoRepositorio.Add(enderecoModel);

            //await LogMovimentacaoService.InserirLogMov(enderecoModel, 1, "Endereço", enderecoModel.Id);
            //await LogMovimentacaoService.InserirLogMov(pessoaModel, 1, "Pessoa", pessoaModel.Id);

            var result = Mapper.Map<EnderecoDto>(enderecoModel);

            return result;
        }

        public async Task<EnderecoDto> AlterarEndereco(TipoEnderecoEnum tipoEndereco, EnderecoDto endereco)
        {
            //var pessoaModel = await Repositorio.FindById(idPessoa);
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

            //await LogMovimentacaoService.InserirLogMov(enderecoModel, 2, "Endereco", enderecoModel.Id);
            //await LogMovimentacaoService.InserirLogMov(pessoaModel, 2, "Pessoa", pessoaModel.Id);

            return result;
        }

        public async Task<ContatoDto> AlterarContato(int idPessoa, TipoContatoEnum tipoContato, ContatoDto contato)
        {
            //var pessoaModel = await Repositorio.FindById(idPessoa);
            var contatoModel = await ContatoRepositorio.FindById(contato.Codigo);
            contatoModel.Nome = contato.Nome;
            contatoModel.Telefone = contato.Telefone;
            contatoModel.Email = contato.Email;
            contatoModel.Situacao = contato.Situacao;
            contatoModel.TipoContato = tipoContato;

            contatoModel = await ContatoRepositorio.Replace(contatoModel.Id, contatoModel);

            var result = Mapper.Map<ContatoDto>(contatoModel);

            return result;
        }

        public override async Task<PessoaDto> Update(int id, PessoaDto pessoa)
        {
            var pessoaDto = await base.Update(id, pessoa);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            //await LogMovimentacaoService.InserirLogMov(pessoaModel, 2, "Pessoa", pessoaModel.Id);

            var result = await base.FindByCodigo(pessoaModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var pessoaDto = await base.FindByCodigo(id);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            //var enderecoModel = pessoaModel.Enderecos.FirstOrDefault(ep => ep.IdPessoa == id);

            //var contatoModel = pessoaModel.Contatos.FirstOrDefault(cp => cp.IdPessoa == id);

            //var logMovEndereco = await LogMovimentacaoService.InserirLogMov(enderecoModel, 3, "Endereco", enderecoModel.Id);
            //if (logMovEndereco!= null)
            //{
            //    var logMovContato = await LogMovimentacaoService.InserirLogMov(contatoModel, 3, "Contato", contatoModel.Id);
            //    if (logMovContato != null)
            //    {
            //        var logMovPessoa = await LogMovimentacaoService.InserirLogMov(pessoaModel, 3, "Pessoa", pessoaModel.Id);
            //        if (logMovPessoa != null)
            //        {
            await base.Delete(pessoaDto.Codigo);
            //        }
            //    }

            //}



        }

        public async Task DeleteContato(int codPessoa, int codContato)
        {
            var pessoaModel = await Repositorio.FindById(codPessoa);
            var contatoModel = pessoaModel.Contatos
                            .FirstOrDefault(cc => cc.Id == codContato);
            var contatoDto = await base.FindByCodigo(codPessoa);
            if (pessoaModel is not null)
            {
                await ContatoRepositorio.Remove(codContato);
            }
        }
        public async Task DeleteEndereco(int codPessoa, int codEndereco)
        {
            var pessoaModel = await Repositorio.FindById(codPessoa);
            var enderecoModel = pessoaModel.Enderecos
                                .FirstOrDefault(ee => ee.Id == codEndereco);

            var pessoaDto = await base.FindByCodigo(codPessoa);

            if (pessoaModel is not null)
            {
                //var logMov = await LogMovimentacaoService.InserirLogMov(enderecoModel, 3, "Endereco", enderecoModel.Id);
                //if (logMov != null)
                //{
                await EnderecoRepositorio.Remove(codEndereco);
                //}

            }

        }
    }
}
