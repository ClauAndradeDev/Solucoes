using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioService UsuarioService { get; set; }
        public UsuarioController(UsuarioService usuarioService)
        {
            UsuarioService = usuarioService;
        }

        //[HttpPost("{codigo}/usuario")]
        //public async Task<IActionResult> InserirUsuarioPessoa(int codigo, UsuarioDto usuario)
        //{
        //    var result = await PessoaService.UsuarioService.InserirUsuarioPessoa(codigo, usuario);
        //    if (result.Codigo != 0)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return Ok("Usuario não incluido!");
        //    }
        //}

        //[HttpPut("{codigo}/usuarioalterar")]
        //public async Task<IActionResult> AlterarUsuarioPessoa(int codigo, UsuarioDto usuario)
        //{
        //    var result = await PessoaService.UsuarioService.AlterarUsuarioPessoa(codigo, usuario);
        //    if (result.Codigo != 0)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return Ok("Usuario não localizado!");
        //    }
        //}

        //[HttpPost("/acesso")]
        //public async Task<IActionResult> AcessoUsuario(UsuarioDto usuario)
        //{
        //    var result = await PessoaService.UsuarioService.AcessoUsuario(usuario);
        //    if (result.Codigo != 0)
        //    {
        //        return Ok(new { Message = "Autorizado" });
        //    }
        //    else
        //    {
        //        return Ok("Verificar Usuário e/ou Senha incorretos!");
        //    }
        //}

        

        //[HttpPut("{codigo}/alterarSenha")]
        //public async Task<IActionResult> AlterarSenha(int codigo, UsuarioDto usuario)
        //{
        //    var result = await PessoaService.AlterarSenhaUsuario(codigo, usuario);
        //    return Ok(result);
        //}
    }
}
