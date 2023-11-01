using Microsoft.AspNetCore.Mvc;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;

namespace Solucoes.Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public TicketMovService TicketService { get; set; }

        public TicketController(TicketMovService ticketService)
        {
            TicketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await TicketService.All();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InserirTicket(TicketDto ticket)
        {
            var result = await TicketService.InserirTicket(ticket);
            return Ok(result);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            var result = await TicketService.BuscarTicketPorId(codigo);
            //var result = await TicketService.FindByCodigo(codigo);
            return Ok(result);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> AlterarTicket(int codigo, TicketDto ticket)
        {
            var result = await TicketService.AlterarTicket(codigo, ticket);
            return Ok(result);
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> ExcluirTicket(int codigo)
        {
            await TicketService.ExcluirTicket(codigo);
            return Ok();
        }

        //Rotas TicketAcao Movimentação
        [HttpPost("{codigo}/TicketAcao")]
        public async Task<IActionResult> IncluirNovaAcaoTicket(int codigo, TicketAcaoDto ticketAcao)
        {
            var result = await TicketService.IncluirNovoTicketAcao(codigo, ticketAcao);
            return Ok(result);
        }

        [HttpPut("{codigo}/TicketAcao")]
        public async Task<IActionResult> AlterarTicketAcao(int codigo, TicketAcaoDto ticketAcao)
        {
            var result = await TicketService.AlterarTicketAcao(codigo, ticketAcao);
            return Ok(result);
        }

        [HttpDelete("{codigo}/TicketAcao")]
        public async Task<IActionResult> ExcluirTicketAcao(int codigo, TicketAcaoDto ticketAcao)
        {
            await TicketService.ExcluirTicketAcao(codigo, ticketAcao);
            return Ok();
        }
    }
}
