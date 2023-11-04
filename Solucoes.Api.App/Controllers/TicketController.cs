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
        public TicketService TicketService { get; set; }

        public TicketController(TicketService ticketService)
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

        //Rotas TicketAgrupamento e TicketRelacionamento
        [HttpPost("{codigo}/Vinculo/{codigoOrigem}")]
        public async Task<IActionResult> VincularTickets(int codigo, int codigoOrigem)
        {
            var result = await TicketService.VincularTickets(codigo, codigoOrigem);
            return Ok(result);
        }

        //Rotas Reuniao E ReuniaoAcao
        [HttpPost("{codigo}/Reuniao")]
        public async Task<IActionResult> InserirReuniao(int codigo, ReuniaoDto reuniao)
        {
            var result = await TicketService.InserirReuniao(codigo, reuniao);
            return Ok(result);
        }

        [HttpPut("{codigo}/Reuniao")]
        public async Task<IActionResult> AlterarReuniao(int codigo, ReuniaoDto reuniao)
        {
            var result = await TicketService.AlterarReuniao(codigo, reuniao);
            return Ok(result);  
        }

        [HttpDelete("{codigo}/Reuniao/{codigoReuniao}")]
        public async Task<IActionResult> ExcluirReuniao(int codigo, int codigoReuniao)
        {
            await TicketService.ExcluirReuniao(codigo, codigoReuniao);
            return Ok();
        }

        [HttpPost("{codigo}/Reuniao/{codReuniao}/ReuniaoAcao")]
        public async Task<IActionResult> InserirNovaAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await TicketService.InserirNovaAcaoReuniao(codigo, codReuniao, reuniaoAcao);
            return Ok(result);
        }

        [HttpPut("{codigo}/Reuniao/{codReuniao}/ReuniaoAcao")]
        public async Task<IActionResult> AlterarAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await TicketService.AlterarAcaoReuniao(codigo, codReuniao, reuniaoAcao);
            return Ok(result);
        }

        [HttpDelete("/Reuniao/{codigoReuniao}/ReuniaoAcao")]
        public async Task<IActionResult> ExcluirAcaoReuniao(int codigo, ReuniaoAcaoDto reuniaoAcao)
        {
            await TicketService.ExcluirAcaoReuniao(codigo, reuniaoAcao);
            return Ok();
        }
    }
}
