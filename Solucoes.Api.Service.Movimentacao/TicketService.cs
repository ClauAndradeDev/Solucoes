using AutoMapper.Execution;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Enums;
using Solucoes.Modelo.Extensoes;
using System.Net.Sockets;
using System.Reflection;

namespace Solucoes.Api.Service.Movimentacao
{
    public class TicketService : CrudServices<Ticket, TicketDto>
    {
        public TicketAcaoRepositorio TicketAcaoRepositorio { get; set; }
        public TicketAcaoService TicketAcaoService { get; set; }
        public TicketAgrupamentoRepositorio TicketAgrupamentoRepositorio { get; set; }
        public TicketAgrupamentoService TicketAgrupamentoService { get; set; }
        public TicketRelacionamentoRepositorio TicketRelacionamentoRepositorio { get; set; }
        public TicketRelacionamentoService TicketRelacionamentoService { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        public PlataformaRepositorio PlataformaRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }
        public PessoaRepositorio PessoaRepositorio { get; set; }
        public ReuniaoService ReuniaoService { get; set; }
        public ReuniaoAcaoService ReuniaoAcaoService { get; set; }

        public TicketService(TicketRepositorio ticketRepositorio
                    , TicketAgrupamentoService ticketAgrupamentoService
                    , TicketAgrupamentoRepositorio ticketAgrupamentoRepositorio
                    , TicketRelacionamentoRepositorio ticketRelacionamentoRepositorio
                    , TicketRelacionamentoService ticketRelacionamentoService
                    , EmpresaRepositorio empresaRepositorio
                    , PlataformaRepositorio plataformaRepositorio
                    , UsuarioRepositorio usuarioRepositorio
                    , ReuniaoService reuniaoService
                    , ReuniaoAcaoService reuniaoAcaoService
                    , TicketAcaoRepositorio ticketAcaoRepositorio
                    , PessoaRepositorio pessoaRepositorio
                    , TicketAcaoService ticketAcaoService
                    , Mapper.Mapper mapper) :
                    base(ticketRepositorio, mapper)
        {
            TicketRelacionamentoService = ticketRelacionamentoService;
            TicketAgrupamentoRepositorio = ticketAgrupamentoRepositorio;
            TicketAgrupamentoService = ticketAgrupamentoService;
            TicketRelacionamentoRepositorio = ticketRelacionamentoRepositorio;
            EmpresaRepositorio = empresaRepositorio;
            PlataformaRepositorio = plataformaRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            TicketAcaoRepositorio = ticketAcaoRepositorio;
            TicketAcaoService = ticketAcaoService;
            PessoaRepositorio = pessoaRepositorio;
            ReuniaoService = reuniaoService;
            ReuniaoAcaoService = reuniaoAcaoService;
        }


        public async Task<TicketDto> BuscarTicketPorId(int codigo)
        {
            var ticketDto = await base.FindByCodigo(codigo);
            var result = ticketDto;
            return result;
        }

        public async Task<TicketDto> InserirTicket(TicketDto ticket)
        {
            var empresaModel = await EmpresaRepositorio.FindById(ticket.Empresa.Codigo);
            var plataformaModel = await PlataformaRepositorio.FindById(ticket.Plataforma.Codigo);

            var ticketAcoes = ticket.TicketAcoes.ToList();

            var ticketAlteradoModel = Mapper.Map<Ticket>(ticket);
            var ticketDto = new TicketDto();
            var result = new TicketDto();

            if (empresaModel != null)
            {
                if (plataformaModel != null)
                {
                    ticketAlteradoModel.DataAbertura = DateTime.Now;
                    ticketAlteradoModel.DataAlteracao = DateTime.Now;
                    ticketAlteradoModel.Plataforma = null;
                    ticketAlteradoModel.Empresa = null;
                    ticketAlteradoModel.PlataformaId = plataformaModel.Id;
                    ticketAlteradoModel.EmpresaId = empresaModel.Id;
                    ticketAlteradoModel.TicketAcoes = null;
                    ticketAlteradoModel = await Repositorio.Add(ticketAlteradoModel);
                    //posso consultar o ultimo idInserido, gerar o NumeroSequencial e só então salvar
                    /*Confirmar após estar funcionando*/
                    ticketAlteradoModel.NumeroSequencial = Conversoes.GerarNumeroSequencialTicket(ticketAlteradoModel.Id);
                    ticketAlteradoModel = await Repositorio.Replace(ticketAlteradoModel.Id, ticketAlteradoModel);

                    //if (usuarioModel != null)
                    //{
                    if (ticketAcoes is not null)
                    {
                        var ticketAcaoInserir = ticketAcoes[0];
                        ticketAcaoInserir.DataAcao = DateTime.Now;
                        var ticketAcaoInserirModel = Mapper.Map<TicketAcao>(ticketAcaoInserir);

                        ticketAcaoInserirModel.DataAcao = DateTime.Now;
                        ticketAcaoInserirModel.UsuarioId = ticketAcaoInserir.Usuario.Codigo;
                        int UsuarioId = (int)ticketAcaoInserirModel.UsuarioId;
                        var usuarioModel = await UsuarioRepositorio.FindById(UsuarioId);

                        //insere TicketAcao
                        var ticketAcaoDto = Mapper.Map<TicketAcaoDto>(ticketAcaoInserirModel);
                        ticketAcaoDto.Usuario = Mapper.Map<UsuarioDto>(usuarioModel);

                        ticketDto = await base.FindByCodigo(ticketAlteradoModel.Id);
                        var ticketAcaoIncluido = await TicketAcaoService.InserirTicketAcao(ticketDto.Codigo, ticketAcaoDto);

                        result = await base.FindByCodigo(ticketAlteradoModel.Id);
                    }

                    //}

                }
            }

            // var result = ticketDto;
            return result;
        }

        public async Task<TicketDto> AlterarTicket(int codTicket, TicketDto ticket)
        {
            var ticketModelBase = await Repositorio.FindById(codTicket);
            var ticketModelAlterado = Mapper.Map<Ticket>(ticket);
            var ticketModelbanco = new Ticket();
            var ticketAcoesBase = ticketModelBase.TicketAcoes.ToList();
            var ticketAcoesAlterado = ticketModelAlterado.TicketAcoes.ToList();

            var empresaModel = new Empresa();
            var plataformaModel = new Plataforma();

            if (ticketModelAlterado != null)
            {
                if (ticketModelBase != null)
                {
                    empresaModel = await EmpresaRepositorio.FindById(ticketModelAlterado.Empresa.Id);
                    plataformaModel = await PlataformaRepositorio.FindById(ticketModelAlterado.Plataforma.Id);

                    if (!ticketModelAlterado.Empresa.Equals(empresaModel.Id))
                    {
                        ticketModelAlterado.EmpresaId = empresaModel.Id;
                        //ticketModelBase.Empresa = ticketModelAlterado.Empresa;
                        //ticketModelBase.EmpresaId = ticketModelAlterado.Empresa.Id;
                        if (!ticketModelAlterado.Plataforma.Equals(plataformaModel.Id))
                        {
                            //ticketModelBase.Plataforma = ticketModelAlterado.Plataforma;
                            //ticketModelBase.PlataformaId = ticketModelAlterado.Plataforma.Id;
                            ticketModelAlterado.PlataformaId = plataformaModel.Id;
                            ticketModelAlterado.DataAbertura = ticketModelBase.DataAbertura;
                            ticketModelAlterado.DataAlteracao = DateTime.Now;
                            ticketModelAlterado.NumeroSequencial = ticketModelBase.NumeroSequencial;

                            ticketModelbanco = await Repositorio.Replace(ticketModelAlterado.Id, ticketModelAlterado);
                        }
                    }
                }

            }

            if (ticketAcoesBase is not null)
            {
                if (ticketAcoesAlterado is not null)
                {
                    var ticketAcaoAlterar = ticketAcoesAlterado[0];

                    var ticketAcaoAlterarModel = Mapper.Map<TicketAcao>(ticketAcaoAlterar);
                    //ticketAcaoAlterarModel.DataAcao = DateTime.Now;
                    ticketAcaoAlterarModel.UsuarioId = ticket.TicketAcoes[0].Usuario.Codigo;
                    //int UsuarioId = (int)ticketAcaoAlterarModel.UsuarioId;
                    int UsuarioId = ticket.TicketAcoes[0].Usuario.Codigo;
                    var usuarioModel = await UsuarioRepositorio.FindById(UsuarioId);
                    ticketAcaoAlterarModel.TicketId = ticketModelbanco.Id;
                    //insere TicketAcao
                    var ticketAcaoDto = Mapper.Map<TicketAcaoDto>(ticketAcaoAlterar);
                    ticketAcaoDto.Usuario = Mapper.Map<UsuarioDto>(usuarioModel);


                    var ticketDto = Mapper.Map<TicketDto>(ticketModelbanco);
                    await TicketAcaoService.AlterarTicketAcao(ticketDto.Codigo, ticketAcaoDto);




                }
            }

            var result = await base.FindByCodigo(ticketModelbanco.Id);

            return result;
        }

        public async Task<TicketDto> ExcluirTicket(int codTicket)
        {
            var ticketModel = await Repositorio.FindById(codTicket);

            if (ticketModel is not null)
            {
                var ticketAcaoExistente = await TicketAcaoService
                                .BuscarTicketAcaoPorTicket(ticketModel.Id);
                var listaTicketAcao = await TicketAcaoRepositorio.All();

                var ehAdministracao = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Adminitração);
                var ehFinanceiro = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Financeiro);
                var ehImplantacao = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Implantação);

                var permissaoExcluir = ehAdministracao.Or(ehFinanceiro).Or(ehImplantacao);

                //Busco TicketAgrupamento, e TicketRElacionamento
                var ticketAgrupamento = await BuscarTicketPorId(ticketModel.Id);
                var ticketRelacionamento = await TicketRelacionamentoService.BuscarTicketRelacionamentoPorTicket(ticketModel.Id);

                //verifico se existem reuniões vinculadas a esse ticket
                var reuniaoModel = await ReuniaoService.BuscarReuniaoPorTicket(codTicket);

              
                if (!ticketAgrupamento.Codigo.Equals(codTicket))
                {
                    if (!ticketRelacionamento.CodigoTicketAgrupamento.Equals(ticketAgrupamento.Codigo))
                    {
                        //pode excluir
                        if (reuniaoModel is null) //se não existir Reuniao Vinculado ao Ticket, segue para excluisão
                        {
                            if (permissaoExcluir) //se tiver permissão para excluir
                            {
                                if (ticketAcaoExistente.Count() > 1)
                                {
                                    //existem mais de 1 ação
                                    foreach (var item in ticketAcaoExistente.ToArray())
                                    {
                                        foreach (var item1 in listaTicketAcao)
                                        {
                                            if (item.Codigo == item1.Id)
                                            {
                                                await TicketAcaoRepositorio.Remove(item1.Id);
                                            }
                                        }
                                    }
                                }
                                else if (ticketAcaoExistente.Count() == 1)
                                {
                                    //apenas 1 ação
                                    await TicketAcaoRepositorio.Remove(ticketAcaoExistente[0].Codigo);
                                }

                                var ticketAserRemovido = await Repositorio.FindById(ticketModel.Id);

                                await Repositorio.Remove(ticketAserRemovido.Id);
                            }
                            else //se não tiver permissão
                            {

                            }

                        }
                    }
                }

            }
            var result = await base.FindByCodigo(ticketModel.Id);
            return result;
        }

        //rota TicketAcao
        public async Task<TicketAcaoDto> IncluirNovoTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var ticketModelBase = await Repositorio.FindById(codTicket);
            var ticketModelbanco = new Ticket();
            var ticketAcoesBase = ticketModelBase.TicketAcoes.ToList();



            var ticketAcaoInserir = ticketAcao;
            var ticketAcaoInserirModel = Mapper.Map<TicketAcao>(ticketAcaoInserir);
            ticketAcaoInserirModel.UsuarioId = ticketAcaoInserir.Usuario.Codigo;
            int UsuarioId = (int)ticketAcaoInserirModel.UsuarioId;
            var usuarioModel = await UsuarioRepositorio.FindById(UsuarioId);

            //insere TicketAcao
            var ticketAcaoDto = Mapper.Map<TicketAcaoDto>(ticketAcaoInserirModel);
            ticketAcaoDto.Usuario = Mapper.Map<UsuarioDto>(usuarioModel);

            //var ticketDto = await base.FindByCodigo(ticketAlteradoModel.Id);
            var ticketAcaoIncluido = await TicketAcaoService.InserirTicketAcao(ticketModelBase.Id, ticketAcaoDto);

            //var ticketAcaoIncluidoDto = await TicketAcaoRepositorio.FindById(ticketAcaoIncluido.Codigo);

            //ticketAcaoIncluidoDto = Mapper.Map<TicketAcaoDto>(ticketAcaoIncluidoDto);
            var result = ticketAcaoIncluido;



            return result;
        }
        public async Task<TicketAcaoDto> AlterarTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var result = await TicketAcaoService.AlterarTicketAcao(codTicket, ticketAcao);
            return result;
        }
        public async Task ExcluirTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            await TicketAcaoService.ExcluirTicketAcao(codTicket, ticketAcao);
        }

        //Rota Vincular Ticket em TicketOrigem
        public async Task<TicketDto> VincularTickets(int codigo, int codTiketOrigem)
        {
            var ticketModelOrigem = await Repositorio.FindById(codTiketOrigem);
            var ticketModelVincular = await Repositorio.FindById(codigo);


            var ticketOrigemDto = Mapper.Map<TicketDto>(ticketModelOrigem);
            var ticketVincularDto = Mapper.Map<TicketDto>(ticketModelVincular);


            try
            {
                ticketOrigemDto.Origem = true;
                //atualizo o ticket com origem = true;
                await base.Update(ticketOrigemDto.Codigo, ticketOrigemDto);

                //inserir ticketAgrupamento.
                var ticketAgrupamento = await TicketAgrupamentoService.InserirTicketOrigem(ticketModelOrigem.Id);

                //pegar idTicketAgrupamento
                var idTicketAgrupamento = ticketAgrupamento.CodigoAgrupamento;

                //inserir ticketRelacionamento (idTicket, e idTicketAgrupamento)
                await TicketRelacionamentoService.InserirRelacaoEntreTickets(idTicketAgrupamento, ticketModelVincular.Id);
            }
            catch (Exception)
            {

                throw;
            }


            var result = await base.FindByCodigo(ticketModelOrigem.Id);

            return result;
        }

        //Rota Ticket -> Reunião
        public async Task<ReuniaoDto> InserirReuniao(int codTicket, ReuniaoDto reuniao)
        {
            var result = await ReuniaoService.InserirReuniao(codTicket, reuniao);
            return result;
        }
        public async Task<ReuniaoDto> AlterarReuniao(int codTicket, ReuniaoDto reuniao)
        {
            var result = await ReuniaoService.AlterarReuniao(codTicket, reuniao);
            return result;
        }
        public async Task ExcluirReuniao(int codTicket, int codReuniao)
        {
            await ReuniaoService.ExcluirReuniao(codTicket, codReuniao);
        }

        //Rota Ticket -> ReuniãoAção
        public async Task<ReuniaoAcaoDto> InserirNovaAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await ReuniaoService.InserirNovaAcaoReuniao(codigo, codReuniao, reuniaoAcao);
            return result;
        }

        public async Task<ReuniaoAcaoDto> AlterarAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await ReuniaoAcaoService.AlterarAcaoReuniao(codigo, codReuniao, reuniaoAcao);
            return result;
        }

        public async Task ExcluirAcaoReuniao(int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            await ReuniaoAcaoService.ExcluirAcaoReuniao(codReuniao, reuniaoAcao);

        }
    }
}
