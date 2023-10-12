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
        public PessoaRepositorio PessoaRepositorio { get; set; }
       // public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public UsuarioService(UsuarioRepositorio usuarioRepositorio,
                            Mapper.Mapper mapper,
                           // LogMovimentacaoService logMovimentacaoService,
                            PessoaRepositorio pesoaRepositorio) :
            base(usuarioRepositorio, mapper)
        {
            //LogMovimentacaoService = logMovimentacaoService;
            PessoaRepositorio = pesoaRepositorio;
        }

        public override async Task<UsuarioDto> Insert(UsuarioDto usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            var usuarioDto = await base.Insert(usuario);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);

            //var pessoaDto = usuarioDto.Pessoas;
            //int codPessoa = 0;
            //foreach (PessoaDto p in pessoaDto)
            //{
            //    codPessoa = p.Codigo;
            //}
           
            //var pessoaModel = await PessoaRepositorio.FindById(codPessoa);

           var result = await base.FindByCodigo(usuarioModel.Id);

           //var logMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 1, "Usuario", usuarioModel.Id);

            return result;
        }

        public override async Task<UsuarioDto> Update(int id, UsuarioDto usuario)
        {
            var usuarioDto = await base.Update(id, usuario);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);

            var result = await base.FindByCodigo(usuarioModel.Id);

           //var LogMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 2, "Usuario", usuarioModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var usuarioDto = await base.FindByCodigo(id);
            var usuarioModel = await base.ReturnModel(usuarioDto.Codigo);

           // var logMovUsuario = await LogMovimentacaoService.InserirLogMov(usuarioModel, 3, "Usuario", usuarioModel.Id);

            await base.Delete(usuarioDto.Codigo);
        }
    }
}
