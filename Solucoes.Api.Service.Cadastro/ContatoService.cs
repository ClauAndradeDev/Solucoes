using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Service;
using Solucoes.Api.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class ContatoService : CrudServices<Contato, ContatoDto>
    {
        public PessoaRepositorio PessoaRepositorio { get; set; }
        public LogMovimentacaoService LogMovimentacaoService { get; set; }

        public ContatoService(ContatoRepositorio contatoRepositorio, 
            PessoaRepositorio pessoaRepositorio,
            LogMovimentacaoService logMovimentacaoService,
            Mapper.Mapper mapper) : base(contatoRepositorio, mapper)
        {
            PessoaRepositorio = pessoaRepositorio;
            LogMovimentacaoService = logMovimentacaoService;
        }

        public override async Task<ContatoDto> Insert(ContatoDto contato)
        {
            var contatoDto = await base.Insert(contato);
            var contatoModel = await base.ReturnModel(contatoDto.Codigo);

            var result = await base.FindByCodigo(contatoModel.Id);

            var logMovContato = await LogMovimentacaoService.InserirLogMov(contatoModel, 1, "Contato", contatoModel.Id);

            return result;
        }

        public override async Task<ContatoDto> Update(int id, ContatoDto contato)
        {
            var contatoDto = await base.Update(id, contato);
            var contatoModel = await base.ReturnModel(contatoDto.Codigo);

            var result = await base.FindByCodigo(contatoModel.Id);

            var logMovContato = await LogMovimentacaoService.InserirLogMov(contatoModel, 2, "Contato", contatoModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var contatoDto = await base.FindByCodigo(id);
            var contatoModel = await base.ReturnModel(contatoDto.Codigo);

            var logMovContato = await LogMovimentacaoService.InserirLogMov(contatoModel, 3, "Contato", contatoModel.Id);

            await base.Delete(contatoDto.Codigo);
        }

    }
}
