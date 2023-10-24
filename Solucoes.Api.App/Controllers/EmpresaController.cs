﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> InserirEmpresa(EmpresaDto empresa)
        {
            var result = await EmpresaService.InserirEmpresa(empresa);
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
        public async Task<IActionResult> AlterarEmpresa(int codigo, EmpresaDto empresa)
        {
            var result = await EmpresaService.AlterarEmpresa(codigo, empresa);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            await EmpresaService.ExcluirEmpresa(codigo);
            //await EmpresaService.Delete(codigo);
            return Ok();
        }

      
        //rotas SetorEmpresa
        [HttpPost("{codigo}/setor")]
        public async Task<ActionResult> PostSetor(int codigo, SetorDto setor)
        {
            var result = await EmpresaService.AdicionarSetorEmpresa(codigo, setor);
            return Ok(result);
        }

        [HttpPut("{codigo}/setor/{codigoSetor}")]
        public async Task<ActionResult> AlterarSetor(int codigo, SetorDto setor)
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

        [HttpGet("{codigo}/setor/")]
        public async Task<ActionResult> BuscarSetorPorEmpresa(int codigo)
        {
            var result = await EmpresaService.SetorEmpresaService.BuscarSetorPorEmpresa(codigo);
            return Ok(result);
        }


        //rotas PlataformaEmpresa
        [HttpPost("{codigo}/plataforma")]
        public async Task<ActionResult> AdicionarPlataforma(int codigo, PlataformaDto plataforma)
        {
            var result = await EmpresaService.AdicionarPlataformaEmpresa(codigo, plataforma);
            return Ok(result);
        }

        [HttpPut("{codigo}/plataforma/")]
        public async Task<ActionResult> AlterarPlataforma(int codigo, PlataformaDto plataforma)
        {
            var result = await EmpresaService.AlterarPlataformaEmpresa(codigo, plataforma);
            return Ok(result);
        }

        [HttpDelete("{codigo}/plataforma/{codigoPlataforma}")]
        public async Task<ActionResult> DeletePlataformaEmpresa(int codigo, int codigoPlataforma)
        {
            await EmpresaService.DeletePlataformaEmpresa(codigo, codigoPlataforma);
            return Ok();
        }

        [HttpGet("{codigo}/plataforma/")]
        public async Task<ActionResult> BuscarPlataformaPorEmpresa(int codigo)
        {
            var result = await EmpresaService.PlataformaService.BuscarPlataformaPorEmpresa(codigo);
            return Ok(result);
        }
    }
}
