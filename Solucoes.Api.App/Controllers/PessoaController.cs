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
        public async Task<IActionResult> InserirPessoa(PessoaDto pessoa)
        {
            var result = await PessoaService.InserirPessoa(pessoa);
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
        public async Task<IActionResult> AlterarPessoa(int codigo, PessoaDto pessoa)
        {
            var result = await PessoaService.AlterarPessoa(codigo, pessoa);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await PessoaService.ExcluirPessoa(codigo);
            return Ok();
        }

        //rotas Endereco
        [HttpPost("{codigo}/endereco")]
        public async Task<IActionResult> AdicionarEndereco(int codigo, EnderecoDto endereco)
        {
            var result = await PessoaService.AdicionarEndereco(codigo, endereco);
            return Ok(result);
        }

        [HttpPut("{codigo}/endereco/")]
        public async Task<IActionResult> AlterarEndereco(int codigo, EnderecoDto endereco)
        {
            var result = await PessoaService.AlterarEndereco(codigo, endereco);
            return Ok(result);
        }

        [HttpDelete("{codigo}/endereco/{codigoEndereco}")]
        public async Task<IActionResult> DeleteEndereco(int codigo, int codigoEndereco)
        {
            await PessoaService.ExcluirEndereco(codigo, codigoEndereco);
            return Ok();
        }
        
        [HttpGet("{codigo}/endereco/")]
        public async Task<IActionResult> BuscarEnderecoPorPessoa(int codigo)
        {
            var result = await PessoaService.EnderecoService.BuscarEnderecoPorPessoa(codigo);
            return Ok(result);
        }


        //rotas Contato
        [HttpPost("{codigo}/contato")]
        public async Task<IActionResult> AdicionarContato(int codigo, ContatoDto contato)
        {
            var result = await PessoaService.AdicionarContato(codigo, contato);
            return Ok(result);
        }

        [HttpPut("{codigo}/contato/")]
        public async Task<IActionResult> AlterarContato(int codigo, ContatoDto contato)
        {
            var result = await PessoaService.AlterarContato(codigo, contato);
            return Ok(result);
        }

        [HttpDelete("{codigo}/contato/{codigoContato}")]
        public async Task<IActionResult> ExcluirContato(int codigo, int codigoContato)
        {
            await PessoaService.ExcluirContato(codigo, codigoContato);
            return Ok();
        }

        [HttpGet("{codigo}/contato")]
        public async Task<IActionResult> BuscarContatoPorPessoa(int codigo)
        {
            var result = await PessoaService.ContatoService.BuscarContatoPorPessoa(codigo);
            return Ok(result);
        }
    }
}
