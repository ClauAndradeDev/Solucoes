using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Movimentacao
{
    public class TicketRelacionamentoMovService : CrudServices<TicketRelacionamento, TicketRelacionamentoDto>
    {
        public TicketRepositorio TicketRepositorio { get; set; }
        public TicketAgrupamentoRepositorio TicketAgrupamentoRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }

        public TicketRelacionamentoMovService(
                            TicketRelacionamentoRepositorio ticketRelacionamentoRepositorio,
                            TicketRepositorio ticketRepositorio,
                            UsuarioRepositorio usuarioRepositorio,
                            TicketAgrupamentoRepositorio ticketAgrupamentoRepositorio,
                            Mapper.Mapper mapper): 
                            base (ticketRelacionamentoRepositorio, mapper)
        {
            TicketRepositorio = ticketRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            TicketAgrupamentoRepositorio = ticketAgrupamentoRepositorio;
        }

        public async Task<TicketRelacionamentoDto> InserirRelacaoEntreTickets(int codTicketAgrupamento, int codTicket)
        {
            var ticketAgrupamento = await TicketAgrupamentoRepositorio.FindById(codTicketAgrupamento);
            var ticketVinculo = await TicketRepositorio.FindById(codTicket);

            var ticketRelacionamento = new TicketRelacionamento();
            if (ticketAgrupamento is not null)
            {
                if(ticketVinculo is not null)
                {
                    ticketRelacionamento.TicketAgrupamentoId = ticketAgrupamento.Id;
                    ticketRelacionamento.TicketId = ticketVinculo.Id;
                    ticketRelacionamento = await Repositorio.Add(ticketRelacionamento);
                }
            }

            var result = await base.FindByCodigo(ticketRelacionamento.Id);
            return result;
        }
    }
}
