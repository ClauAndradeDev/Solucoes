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
        public LogMovimentacaoRepositorio LogMovimentacaoRepositorio { get; set; }
        public EnderecoRepositorio EnderecoRepositorio { get; set; }
        public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public PessoaService(PessoaRepositorio pessoaRepositorio,
            LogMovimentacaoRepositorio logMovimentacaoRepositorio,
            EnderecoRepositorio enderecoRepositorio,
            Mapper.Mapper mapper) : base(pessoaRepositorio, mapper)
        {
            LogMovimentacaoRepositorio = logMovimentacaoRepositorio;
            EnderecoRepositorio = enderecoRepositorio;
        }

        public override async Task<PessoaDto> Insert(PessoaDto pessoa)
        {
            var pessoaDto = await base.Insert(pessoa);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            var logMovPessoa = await LogMovimentacaoService.InserirLogMov(pessoaModel, 1, "Pessoa");

            var result = await base.FindByCodigo(pessoaModel.Id);


            return result;
        }

        public async Task<EnderecoDto> AdicionarEndereco(int idPessoa, TipoEnderecoEnum tipoEndereco, EnderecoDto endereco)
        {
            var pessoaModel = await Repositorio.FindById(idPessoa);

            var enderecoModel = Mapper.Map<Endereco>(endereco);
            enderecoModel = await EnderecoRepositorio.Add(enderecoModel);

            //await InserirLogMov(pessoaModel, 1, "Pessoa");
            //await InserirLogMov(endereco, 1, "Endereco");

            var logMovPessoa = await LogMovimentacaoService.InserirLogMov(pessoaModel, 1, "Pessoa");

            var result = Mapper.Map<EnderecoDto>(enderecoModel);

            return result;
        }

        public async Task<EnderecoDto> AlterarEndereco(int idPessoa, TipoEnderecoEnum tipoEndereco, EnderecoDto endereco)
        {
            var pessoaModel = await Repositorio.FindById(idPessoa);
            var enderecoModel = await EnderecoRepositorio.FindById(endereco.Codigo);
            enderecoModel.Logradouro = endereco.Logradouro;
            enderecoModel.Numero = endereco.Numero;
            enderecoModel.Bairro = endereco.Bairro;
            enderecoModel.CEP = endereco.CEP;
            enderecoModel.Cidade = endereco.Cidade;
            enderecoModel.Estado = endereco.Estado;

            enderecoModel = await EnderecoRepositorio.Replace(enderecoModel.Id, enderecoModel);

            var result = Mapper.Map<EnderecoDto>(enderecoModel);

            var logMovEndereco = await LogMovimentacaoService.InserirLogMov(enderecoModel, 2, "Endereco");

            return result;
        }

        public override async Task<PessoaDto> Update(int id, PessoaDto pessoa)
        {
            var pessoaDto = await base.Update(id, pessoa);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            //await InserirLogMov(pessoaModel, 2, "Pessoa");
            var logMovPessoa = await LogMovimentacaoService.InserirLogMov(pessoaModel, 2, "Pessoa");
            var result = await base.FindByCodigo(pessoaModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var pessoaDto = await base.FindByCodigo(id);
            var pessoaModel = await base.ReturnModel(pessoaDto.Codigo);

            var enderecoModel = pessoaModel.Enderecos.FirstOrDefault(ep => ep.IdPessoa == id);

            var contatoModel = pessoaModel.Contatos.FirstOrDefault(cp => cp.IdPessoa == id);

            var logMovEndereco = await LogMovimentacaoService.InserirLogMov(enderecoModel, 3, "Endereco");
            if (logMovEndereco!= null)
            {
                var logMovContato = await LogMovimentacaoService.InserirLogMov(contatoModel, 3, "Contato");
                if (logMovContato != null)
                {
                    var logMovPessoa = await LogMovimentacaoService.InserirLogMov(pessoaModel, 3, "Pessoa");
                    if (logMovPessoa != null)
                    {
                        await base.Delete(pessoaDto.Codigo);
                    }
                }
               
            }

            

        }

        public async Task DeleteEndereco(int codPessoa, int codEndereco)
        {
            var pessoaModel = await Repositorio.FindById(codPessoa);
            var enderecoModel = pessoaModel.Enderecos
                                .FirstOrDefault(ee => ee.Id == codEndereco);

            var pessoaDto = await base.FindByCodigo(codPessoa);

            if (!(pessoaModel is null))
            {
                var logMov = await LogMovimentacaoService.InserirLogMov(enderecoModel, 3, "Endereco");
                if (logMov != null)
                {
                    await EnderecoRepositorio.Remove(codEndereco);
                }
                
            }

        }

        //public async Task InserirLogMov(Object objeto, int situacao, string tabela)
        //{
        //    var logMov = new LogMovimentacao();


        //    logMov.DataAlteracao = DateTime.Today;
        //    logMov.Movimentacao = (Modelo.Enums.SituacaoRegistroEnum)situacao;
        //    logMov.Tabela = tabela;
        //    logMov.Conteudo = (System.Text.Json.Nodes.JsonArray?)Helpers.ConverterObjectJson(objeto);

        //    await LogMovimentacaoRepositorio.Add(logMov);
        //}
    }
}
