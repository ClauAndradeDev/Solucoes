using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Enums;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public EmpresaService EmpresaService { get; set; }

        public EmpresaController(EmpresaService empresaService)
        {
            EmpresaService = empresaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmpresaDto empresa)
        {
            var result = await EmpresaService.Insert(empresa);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await EmpresaService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await EmpresaService.All();
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, EmpresaDto empresa)
        {
            var result = await EmpresaService.Update(codigo, empresa);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await EmpresaService.Delete(codigo);
            return Ok();
        }

        //rotas Endereco
        [HttpPost("{codigo}/endereco")]
        public async Task<ActionResult> PostEndereco(int codigo, EnderecoDto endereco)
        {
            var result = await EmpresaService.AdicionarEndereco(codigo, endereco);
            return Ok(result);
        }

        [HttpPut("{codigo}/endereco/{codigoEndereco}")]
        public async Task<ActionResult> AlterarEndereco(TipoEnderecoEnum tipo, EnderecoDto endereco)
        {
            var result = await EmpresaService.AlterarEndereco(tipo, endereco);
            return Ok(result);
        }

        [HttpDelete("{codigo}/endereco/{codigoEndereco}")]
        public async Task<ActionResult> DeleteEndereco(int codigo, int codigoEndereco)
        {
            await EmpresaService.DeleteEndereco(codigo, codigoEndereco);
            return Ok();
        }

        //rotas SetorEmpresa
        [HttpPost("{codigo}/setor")]
        public async Task<ActionResult> PostSetor(int codigo, SetorEmpresaDto setor)
        {
            var result = await EmpresaService.AdicionarSetorEmpresa(codigo, setor);
            return Ok(result);
        }

        [HttpPut("{codigo}/setor/{codigoSetor}")]
        public async Task<ActionResult> AlterarSetor(int codigo, SetorEmpresaDto setor)
        {
            var result = await EmpresaService.AlterarSetorEmpresa(codigo, setor);
            return Ok(result);
        }

        [HttpDelete("{codigo}/setor/{codigoSetor}")]
        public async Task<ActionResult> DeleteSetorEmpresa(int codigo, int codigoSetor)
        {
            await EmpresaService.DeleteSetorEmpresa(codigo, codigoSetor);
            return Ok();
        }

    }
}
