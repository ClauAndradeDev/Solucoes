using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorEmpresaController : ControllerBase
    {
        public SetorEmpresaService SetorEmpresaService { get; set; }

        public SetorEmpresaController(SetorEmpresaService setorEmpresaService)
        {
            SetorEmpresaService = setorEmpresaService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(SetorEmpresaDto setorEmpresa)
        {
            var result = await SetorEmpresaService.Insert(setorEmpresa);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await SetorEmpresaService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await SetorEmpresaService.All();
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, SetorEmpresaDto setorEmpresa)
        {
            var result = await SetorEmpresaService.Update(codigo, setorEmpresa);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await SetorEmpresaService.Delete(codigo);
            return Ok();
        }
    }
}
