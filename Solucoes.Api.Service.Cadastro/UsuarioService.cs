using Solucoes.Api.Mapper;
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
    public class UsuarioService : CrudServices<Usuario, UsuarioDto>
    {
        //public LogMovimentacaoRepositorio LogMovimentacaoRepositorio { get; set; }
        public PessoaRepositorio PesoaRepositorio { get; set; }
        public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public UsuarioService(UsuarioRepositorio usuarioRepositorio,
                            Mapper.Mapper mapper,
                            LogMovimentacaoService logMovimentacaoService,
                            PessoaRepositorio pesoaRepositorio) :
            base(usuarioRepositorio, mapper)
        {
            LogMovimentacaoService = logMovimentacaoService;
            PesoaRepositorio = pesoaRepositorio;
        }

        public override async Task<UsuarioDto> Insert(UsuarioDto usuario)
        {
            
            var usuarioDto = await base.Insert(usuario);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);
        
            var result = await base.FindByCodigo(usuarioModel.Id);

            //await InserirLogMovimentacao(usuarioModel, 1);
            var logMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 1, "Usuario");

            return result;
        }

        public override async Task<UsuarioDto> Update(int id, UsuarioDto usuario)
        {
            var usuarioDto = await base.Update(id, usuario);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);

            var result = await base.FindByCodigo(usuarioModel.Id);

            //await InserirLogMovimentacao(usuarioModel, 2);
            var LogMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 2, "Usuario");

            return result;
        }

        public override async Task Delete(int id)
        {
            var usuarioDto = await base.FindByCodigo(id);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);

            var logMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 3, "Usuario");

            await base.Delete(usuarioDto.Codigo);
        }

        //public async Task InserirLogMovimentacao(Usuario usuario, int situacao)
        //{
        //    //registrar logMovimentação
        //    var logMov = new LogMovimentacao();
        //    var tabela = "Usuario";
        //    var conteudo = usuario;

        //    logMov.DataAlteracao = DateTime.Today;
        //    logMov.Movimentacao = (Modelo.Enums.SituacaoRegistroEnum)situacao;
        //    logMov.Tabela = tabela;
        //    logMov.Conteudo = (System.Text.Json.Nodes.JsonArray?)Helpers.ConverterObjectJson(conteudo);

        //    await LogMovimentacaoRepositorio.Add(logMov);
        //}



    }
}
