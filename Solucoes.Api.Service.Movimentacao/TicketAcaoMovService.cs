using AutoMapper.Execution;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Enums;
using Solucoes.Modelo.Extensoes;
using Solucoes.Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Movimentacao
{
    public class TicketAcaoMovService : CrudServices<TicketAcao, TicketAcaoDto>
    {


        public TicketRepositorio TicketRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }
        public PessoaRepositorio PessoaRepositorio { get; set; }


        public TicketAcaoMovService(TicketAcaoRepositorio ticketAcaoRepositorio
                        , TicketRepositorio ticketRepositorio
                        , UsuarioRepositorio usuarioRepositorio
                        , PessoaRepositorio pessoaRepositorio
                        , Mapper.Mapper mapper)
                        : base(ticketAcaoRepositorio, mapper)
        {
            TicketRepositorio = ticketRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            PessoaRepositorio = pessoaRepositorio;
        }

        public async Task<TicketAcaoDto> InserirTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var ticketModel = await TicketRepositorio.FindById(codTicket);
            var usuarioModel = await UsuarioRepositorio.FindById(ticketAcao.Usuario.Codigo);

            var result = new TicketAcaoDto();
            var ticketAcaoModel = Mapper.Map<TicketAcao>(ticketAcao);
            if (ticketModel is not null)
            {
                if (usuarioModel is not null)
                {
                    //insere ticketAcao
                    ticketAcaoModel.DataAcao = DateTime.Now;
                    ticketAcaoModel.DataUltimaAlteracao = DateTime.Now;
                    ticketAcaoModel.Ticket = null;
                    ticketAcaoModel.Usuario = null;
                    ticketAcaoModel.UsuarioId = usuarioModel.Id;
                    ticketAcaoModel.TicketId = ticketModel.Id;
                    ticketAcaoModel = await Repositorio.Add(ticketAcaoModel);
                    result = await base.FindByCodigo(ticketAcaoModel.Id);
                }
            }
            return result;
        }

        public async Task<TicketAcaoDto> AlterarTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var ticketModel = await TicketRepositorio.FindById(codTicket);
            var ticketAcaoModelBanco = await Repositorio.FindById(ticketAcao.Codigo);
            if (ticketModel is not null)
            {
                ticketAcaoModelBanco.Conteudo = ticketAcao.Conteudo;
                ticketAcaoModelBanco.DataUltimaAlteracao = DateTime.Now;
                await Repositorio.Replace(ticketAcaoModelBanco.Id, ticketAcaoModelBanco);
            }
            var result = Mapper.Map<TicketAcaoDto>(ticketAcaoModelBanco);

            return result;
        }

        public async Task ExcluirTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var ticketModel = await TicketRepositorio.FindById(codTicket);
            var ticketAcaoAexcluir = await Repositorio.FindById(ticketAcao.Codigo);
            var usuarioModel = await UsuarioRepositorio.FindById(ticketAcao.Usuario.Codigo);
            var pessoaModel = await PessoaRepositorio.FindById(ticketAcao.Usuario.Pessoa.Codigo);
            var ticketsAcoes = await BuscarTicketAcaoPorTicket(codTicket);
            if (ticketModel is not null)
            {
                if (ticketAcaoAexcluir is not null)
                {
                    if (usuarioModel is not null)
                    {
                        if (pessoaModel is not null)
                        {
                            var ehAdministracao = pessoaModel.Acesso.Equals(AcessoEnum.Adminitração);
                            var ehImplantacao = pessoaModel.Acesso.Equals(AcessoEnum.Implantação);
                            var ehFinanceiro = pessoaModel.Acesso.Equals(AcessoEnum.Financeiro);

                            var PermissaoExcluir = ehAdministracao.Or(ehImplantacao)
                                                                  .Or(ehFinanceiro);

                            if (PermissaoExcluir)
                            {
                                if(ticketsAcoes.Length == 1)
                                {
                                    //excluir ticket
                                    await TicketRepositorio.Remove(ticketModel.Id);
                                    //excluir ação
                                    await base.Delete(ticketAcao.Codigo);
                                }
                                else
                                {
                                    //retornar mensagem de não possível
                                    await base.Delete(ticketAcao.Codigo);
                                    /*
                                 * Aqui entrará a parte de reorganizar o NumeroSequencial para exibição
                                 */
                                }


                            }
                            else
                            {
                                //retornar não possivel exclusão
                            }
                        }
                    }

                }
            }
        }

        public async Task<TicketAcaoTicketDto[]> BuscarTicketAcaoPorTicket(int codTicket)
        {
            var ticket = await TicketRepositorio.FindById(codTicket);
            var ticketAcoes = ticket.TicketAcoes;
            ticketAcoes ??= new TicketAcao[] { };

            var result = Mapper.Map<TicketAcaoTicketDto[]>(ticketAcoes);
            return result;
        }
    }
}
