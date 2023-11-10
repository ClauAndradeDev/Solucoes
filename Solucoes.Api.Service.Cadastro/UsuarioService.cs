using Solucoes.Api.Mapper;
using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Extensoes;
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


        public async Task<UsuarioDto> InserirUsuarioPessoa(int codPessoa, UsuarioDto usuario)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);

            var usuarioModel = Mapper.Map<Usuario>(usuario);
            var result = new UsuarioDto();

            if (pessoaModel != null)
            {
                var usuarioJaExiste = pessoaModel.Usuarios.Where(p => p.PessoaId == pessoaModel.Id).Any();
                if (usuarioJaExiste)
                {
                    result = await base.FindByCodigo(pessoaModel.Id);
                }
                else
                {
                    usuarioModel.DataCadastro = DateTime.Now;
                    usuarioModel.PessoaId = pessoaModel.Id;
                    var senhaHash = HashMD5.RetornarMD5(usuarioModel.Senha);
                    usuarioModel.Senha = senhaHash;

                    usuarioModel = await Repositorio.Add(usuarioModel);
                    result = await base.FindByCodigo(usuarioModel.Id);
                }

            }
            return result;
        }

        public async Task<UsuarioDto> AlterarUsuarioPessoa(int codPessoa, UsuarioDto usuario)
        {
            var pessoaModel = await PessoaRepositorio.FindById(codPessoa);
            var usuarioModel = new Usuario();

            if (pessoaModel != null)
            {
                usuarioModel = Mapper.Map<Usuario>(usuario);
                var usuariopesoa = pessoaModel.Usuarios.ToArray();

                var usuarioJaExiste = pessoaModel.Usuarios.Where(p => p.PessoaId == pessoaModel.Id).Any();
                if (usuarioJaExiste)
                {
                    usuarioModel.Situacao = (Modelo.Enums.SituacaoCadastralEnum)usuario.Situacao;
                    var senhaHash = HashMD5.RetornarMD5(usuario.Senha);
                    usuarioModel.Senha = senhaHash;
                    await Repositorio.Replace(usuarioModel.Id, usuarioModel);
                }
            }

            var result = Mapper.Map<UsuarioDto>(usuarioModel);
            return result;
        }

        public async Task<UsuarioDto> AcessoUsuario(UsuarioDto usuario)
        {
            var usuarioM = await Repositorio.All();
            var usuarioModel = usuarioM[0];
            //var usuarioLogando = usuario.Login;
            var usuarioDto = new UsuarioDto();

            if (usuarioM is not null)
            {
                foreach (var item in usuarioM)
                {
                    if (!String.IsNullOrEmpty(usuario.Login))
                    {
                        if (!String.IsNullOrEmpty(usuario.Senha))
                        {
                            if (item.Login.Equals(usuario.Login))
                            {
                                var senhaEnviada = HashMD5.RetornarMD5(usuario.Senha);

                                if (senhaEnviada == usuarioModel.Senha)
                                {
                                    usuarioDto = Mapper.Map<UsuarioDto>(usuarioModel);
                                }
                            }
                        }
                    }
                }


            }

            //var usuarioModel = await Repositorio.FindById(usuario.Codigo);
            //var usuarioModelCod = await Repositorio.FindById(codigo);



            //if (!(usuarioModel is null))
            //{
            //    if (usuario.Login == usuarioModel.Login)
            //    {
            //        if (!String.IsNullOrEmpty(usuario.Senha))
            //        {
            //            var senhaEnviada = HashMD5.RetornarMD5(usuario.Senha);

            //            if(senhaEnviada == usuarioModel.Senha)
            //            {
            //                usuarioDto = Mapper.Map<UsuarioDto>(usuarioModel);
            //            }
            //        }
            //    }
            //}

            return usuarioDto;
        }

        public async Task<UsuarioDto> AcessoUsuarioLogar(string login, string senha)
        {
            var usuarioBanco = await Repositorio.All();
            var usuarios = usuarioBanco.ToArray();
            var usuarioModel = new Usuario();
            var usuarioDto = new UsuarioDto();
            var senhaEnviada = HashMD5.RetornarMD5(senha);

            foreach (var item in usuarios)
            {
                if (item.Login == login)
                {
                    if (item.Senha == senhaEnviada)
                    {
                        usuarioModel = await Repositorio.FindById(item.Id);
                        usuarioDto = Mapper.Map<UsuarioPessoaDto>(usuarioModel);
                    }
                }
            }

            return usuarioDto;
        }

        public async Task<UsuarioDto> DeslogarUsuario(string login)
        {
            var usuarioBanco = await Repositorio.All();
            var usuarios = usuarioBanco.ToArray();
            var usuarioModel = new Usuario();
            var usuarioDto = new UsuarioDto();
            foreach (var item in usuarios)
            {
                if (item.Login == login)
                {

                    usuarioModel = await Repositorio.FindById(item.Id);
                    usuarioDto = Mapper.Map<UsuarioDto>(usuarioModel);
                }
            }

            return usuarioDto;
        }

        public async Task<UsuarioDto> AlterarSenhaUsuario(int codigo, UsuarioDto usuario)
        {
            if (!(usuario is null))
            {
                if (!String.IsNullOrEmpty(usuario.Senha))
                {
                    var usuarioModel = await Repositorio.FindById(codigo);
                    var senhaAlterada = HashMD5.RetornarMD5(usuario.Senha);

                    usuarioModel.Senha = senhaAlterada;
                    await Repositorio.Replace(codigo, usuarioModel);

                    usuarioModel = await Repositorio.FindById(codigo);
                    var result = Mapper.Map<UsuarioDto>(usuarioModel);
                    return result;
                }

                //Colocar uma exception decente aqui.
                throw new Exception("A senha digitada não atende aos critérios informados!");
            }

            //Colocar uma exception decente aqui.
            throw new Exception("Usuário não encontrado. Passar bem!");


        }
    }
}
