using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        public PlataformaService PlataformaService { get; set; }

        public PlataformaController(PlataformaService plataformaService)
        {
            PlataformaService = plataformaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlataformaDto plataforma)
        {
            var result = await PlataformaService.Insert(plataforma);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await PlataformaService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await PlataformaService.All();
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, PlataformaDto plataforma)
        {
            var result = await PlataformaService.Update(codigo, plataforma);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await PlataformaService.Delete(codigo);
            return Ok();
        }
    }
}
