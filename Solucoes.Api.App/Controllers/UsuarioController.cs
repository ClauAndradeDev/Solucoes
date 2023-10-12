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

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto usuario)
        {
            var result = await UsuarioService.Insert(usuario);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await UsuarioService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await UsuarioService.All();
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, UsuarioDto usuario)
        {
            var result = await UsuarioService.Update(codigo, usuario);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await UsuarioService.Delete(codigo);
            return Ok();
        }
    }
}
