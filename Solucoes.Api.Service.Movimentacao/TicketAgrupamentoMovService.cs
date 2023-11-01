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
    public class TicketAgrupamentoMovService : CrudServices<TicketAgrupamento, TicketAgrupamentoDto>
    {
        public TicketRepositorio TicketRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }

        public TicketAgrupamentoMovService(TicketAgrupamentoRepositorio ticketAgrupamentoRepositorio
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
 
    //    public async Task<TicketAgrupamentoDto> InserirTicketAcao(int codTicket, TicketAgrupamentoDto ticketAgrupamento)
    //    {
    //        var ticket = await TicketRepositorio.FindById(codTicket);
    //        var usuarioModel = await UsuarioRepositorio.FindById(ticketAgrupamento.Usuario.Codigo);
    //        //var ticketAcaoModel = await Repositorio.All();
    //        var ticketAcaoInclusaoModel = Mapper.Map<TicketAgrupamentoDto>(ticketAgrupamento);
    //        var result = new TicketAgrupamentoDto();

    //        if (ticket != null)
    //        {
    //            //var ticketAcaoExiste = ticket.TicketAcaos.Where(ta => ta.TicketId.Equals(ticket.Id)).Any();  
    //            //if (ticketAcaoExiste)
    //            //{
    //            ////Implementar ao incluir Sequencia. Para sempre mostrar a ação sequente
    //            ////caso tenha sido excluido alguma ação a sequencia não quebre
    //            //}
    //            if (usuarioModel != null)
    //            {
    //                ticketAcaoInclusaoModel.DataAcao = DateTime.Now;
    //                ticketAcaoInclusaoModel.Usuario = usuarioModel;
    //                ticketAcaoInclusaoModel.Ticket = ticket;

    //                ticketAcaoInclusaoModel = await Repositorio.Add(ticketAcaoInclusaoModel);
    //                result = await base.FindByCodigo(ticketAcaoInclusaoModel.Id);
    //            }

    //        }
    //        return result;
    //    }

    //    public async Task<TicketAgrupamentoDto> AlterarTicketAcao(int codTicket, TicketAgrupamentoDto ticketAgrupamento)
    //    {
    //        var ticketModel = await TicketRepositorio.FindById(codTicket);
    //        var ticketAcaoModel = await Repositorio.FindById(ticketAcao.Codigo);

    //        if (ticketModel != null)
    //        {
    //            if (ticketAcaoModel != null)
    //            {
    //                if (ticketModel.TicketAcaos.Where(ta => ta.TicketId == ticketModel.Id).Any())
    //                {
    //                    var ticketAcaoAlterando = Mapper.Map<TicketAcao>(ticketAcao);
    //                    ticketAcaoModel = ticketAcaoAlterando;

    //                    await Repositorio.Replace(ticketAcaoModel.Id, ticketAcaoModel);
    //                }
    //            }
    //        }
    //        var result = Mapper.Map<TicketAcaoDto>(ticketAcaoModel);
    //        return result;
    //    }

    //    public async Task ExcluirTicketAcao(int codTicket, int codTicketAcao)
    //    {
    //        var ticketModel = await TicketRepositorio.FindById(codTicket);
    //        var ticketAcaoModel = await Repositorio.FindById(codTicketAcao);

    //        if (ticketModel != null)
    //        {
    //            if(ticketAcaoModel != null)
    //            {
    //                await Repositorio.Remove(ticketAcaoModel.Id);
    //            }
    //        }
    //    }

    //    public async Task<TicketAgrupamentoDto[]> BuscarTicketAcaoPorTicket(int codTicket)
    //    {
    //        var ticket = await TicketRepositorio.FindById(codTicket);
    //        var acoes = ticket.TicketAcaos;
    //        acoes ??= new TicketAcao[] { };

    //        var result = Mapper.Map<TicketAcaoDto[]>(acoes);
    //        return result;
    //    }
    }
}
