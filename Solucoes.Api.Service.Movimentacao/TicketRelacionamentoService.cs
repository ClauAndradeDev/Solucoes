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
    public class TicketRelacionamentoService : CrudServices<TicketRelacionamento, TicketRelacionamentoDto>
    {
        public TicketRepositorio TicketRepositorio { get; set; }
        public TicketAgrupamentoRepositorio TicketAgrupamentoRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }

        public TicketRelacionamentoService(
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

        public async Task<TicketRelacionamentoDto> BuscarTicketRelacionamentoPorTicket(int codTicket)
        {
            var ticketRelacionamentoModel = await Repositorio.All();
            var ticketAgrupamentoModel = await TicketAgrupamentoRepositorio.All();
            var ticketRelacionamentoDto = new TicketRelacionamentoDto();
            if(ticketRelacionamentoModel is not null)
            {
                if(ticketAgrupamentoModel is not null)
                {
                    foreach (var item in ticketRelacionamentoModel)
                    {
                        if (item.TicketId == codTicket)
                        {
                            var ticketRel = item;
                            ticketRelacionamentoDto = Mapper.Map<TicketRelacionamentoDto>(ticketRel);

                            ////existe relacionamento
                            //foreach (var item1 in ticketAgrupamentoModel)
                            //{
                            //    if (item1.TicketId == codTicket)
                            //    {

                            //    }
                            //}
                        }
                    }
                }
            }
            var result = ticketRelacionamentoDto;
            return result;

        }
    }
}
