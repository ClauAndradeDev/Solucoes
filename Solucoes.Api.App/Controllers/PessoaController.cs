using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Cadastro;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Enums;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        public PessoaService PessoaService { get; set; }

        public PessoaController(PessoaService pessoaService)
        {
            PessoaService = pessoaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PessoaDto pessoa)
        {
            var result = await PessoaService.Insert(pessoa);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await PessoaService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await PessoaService.All();
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Put(int codigo, PessoaDto pessoa)
        {
            var result = await PessoaService.Update(codigo, pessoa);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await PessoaService.Delete(codigo);
            return Ok();
        }

        //rotas Endereco
        [HttpPost("{codigo}/endereco")]
        public async Task<ActionResult> PostEndereco(int codigo, TipoEnderecoEnum tipoEndereco, EnderecoDto endereco)
        {
            var result = await PessoaService.AdicionarEndereco(codigo, tipoEndereco, endereco);
            return Ok(result);
        }

        [HttpPut("{codigo}/endereco/{codigoEndereco}")]
        public async Task<ActionResult> AlterarEndereco(int codPessoa, TipoEnderecoEnum tipo, EnderecoDto endereco)
        {
            var result = await PessoaService.AlterarEndereco(codPessoa, tipo, endereco);
            return Ok(result);
        }

        [HttpDelete("{codigo}/endereco/{codigoEndereco}")]
        public async Task<ActionResult> DeleteEndereco(int codigo, int codigoEndereco)
        {
            await PessoaService.DeleteEndereco(codigo, codigoEndereco);
            return Ok();
        }

        //rotas Contato
        [HttpPost("{codigo}/contato")]
        public async Task<ActionResult> PostContato(int codigo, TipoContatoEnum tipoContato, ContatoDto contato)
        {
            var result = await PessoaService.AdicionarContato(codigo, tipoContato, contato);
            return Ok(result);
        }

        [HttpPut("{codigo}/endereco/{codigoContato}")]
        public async Task<ActionResult> AlterarContato(int codPessoa, TipoContatoEnum tipo, ContatoDto contato)
        {
            var result = await PessoaService.AlterarContato(codPessoa, tipo, contato);
            return Ok(result);
        }

        [HttpDelete("{codigo}/contato/{codigoContato}")]
        public async Task<ActionResult> DeleteContato(int codigo, int codigoContato)
        {
            await PessoaService.DeleteContato(codigo, codigoContato);
            return Ok();
        }
    }
}
