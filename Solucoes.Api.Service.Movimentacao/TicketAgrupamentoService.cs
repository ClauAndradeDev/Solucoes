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
    public class TicketAgrupamentoService : CrudServices<TicketAgrupamento, TicketAgrupamentoDto>
    {
        public TicketRepositorio TicketRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }

        public TicketAgrupamentoService(TicketAgrupamentoRepositorio ticketAgrupamentoRepositorio
                            , TicketRepositorio ticketRepositorio
                            , UsuarioRepositorio usuarioRepositorio
                            , Mapper.Mapper mapper) :
                            base(ticketAgrupamentoRepositorio, mapper)
        {
            TicketRepositorio = ticketRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
        }


        public async Task<TicketAgrupamentoDto> InserirTicketOrigem(int codTicketOrigem)
        {
            var ticketModelOrigem = await TicketRepositorio.FindById(codTicketOrigem);

            var ticketAgrupamento = new TicketAgrupamento();
            if(ticketModelOrigem is not null)
            {
                ticketAgrupamento.TicketId = ticketModelOrigem.Id;
                ticketAgrupamento = await Repositorio.Add(ticketAgrupamento);
            }
           

            var result = await base.FindByCodigo(ticketAgrupamento.Id);

            return result;
        }
    }
}
