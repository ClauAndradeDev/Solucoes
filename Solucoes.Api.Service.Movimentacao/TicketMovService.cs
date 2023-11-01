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
    public class TicketMovService : CrudServices<Ticket, TicketDto>
    {
        public TicketAcaoRepositorio TicketAcaoRepositorio { get; set; }
        public TicketAcaoMovService TicketAcaoMovService { get; set; }
        public TicketAgrupamentoRepositorio TicketAgrupamentoRepositorio { get; set; }
        public TicketAgrupamentoMovService TicketAgrupamentoMovService { get; set; }
        public TicketRelacionamentoRepositorio TicketRelacionamentoRepositorio { get; set; }
        public TicketRelacionamentoMovService TicketRelacionamentoMovService { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        public PlataformaRepositorio PlataformaRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }
        public PessoaRepositorio PessoaRepositorio { get; set; }

        public TicketMovService(TicketRepositorio ticketRepositorio
                    , TicketAgrupamentoMovService ticketAgrupamentoMovService
                    , TicketAgrupamentoRepositorio ticketAgrupamentoRepositorio
                    , TicketRelacionamentoRepositorio ticketRelacionamentoRepositorio
                    , TicketRelacionamentoMovService ticketRelacionamentoMovService
                    , EmpresaRepositorio empresaRepositorio
                    , PlataformaRepositorio plataformaRepositorio
                    , UsuarioRepositorio usuarioRepositorio
                    , Mapper.Mapper mapper
                    , TicketAcaoRepositorio ticketAcaoRepositorio
                    , PessoaRepositorio pessoaRepositorio
                    , TicketAcaoMovService ticketAcaoMovService) :
                    base(ticketRepositorio, mapper)
        {
            TicketRelacionamentoMovService = ticketRelacionamentoMovService;
            TicketAgrupamentoRepositorio = ticketAgrupamentoRepositorio;
            TicketAgrupamentoMovService = ticketAgrupamentoMovService;
            TicketRelacionamentoRepositorio = ticketRelacionamentoRepositorio;
            EmpresaRepositorio = empresaRepositorio;
            PlataformaRepositorio = plataformaRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            TicketAcaoRepositorio = ticketAcaoRepositorio;
            TicketAcaoMovService = ticketAcaoMovService;
            PessoaRepositorio = pessoaRepositorio;
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
                        var ticketAcaoIncluido = await TicketAcaoMovService.InserirTicketAcao(ticketDto.Codigo, ticketAcaoDto);

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
                    await TicketAcaoMovService.AlterarTicketAcao(ticketDto.Codigo, ticketAcaoDto);




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
                var ticketAcaoExistente = await TicketAcaoMovService
                                .BuscarTicketAcaoPorTicket(ticketModel.Id);
                //var ticketAcaoListaDto = ticketAcaoExistente.ToList();
                var listaTicketAcao = await TicketAcaoRepositorio.All();

        
                //var pessoaCodigo = ticketAcaoExistente.ToArray().Select(t=>t.Usuario.Pessoa.Codigo);

                //listaTicketAcao[0].Usuario.Pessoa.Acesso (pegar o acesso da pessoa do usuario)
                var ehAdministracao = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Adminitração);
                var ehFinanceiro = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Financeiro);
                var ehImplantacao = listaTicketAcao[0].Usuario.Pessoa.Acesso.Equals(AcessoEnum.Implantação);

                var permissaoExcluir = ehAdministracao.Or(ehFinanceiro).Or(ehImplantacao);

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
                    else if(ticketAcaoExistente.Count()==1)
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
            var ticketAcaoIncluido = await TicketAcaoMovService.InserirTicketAcao(ticketModelBase.Id, ticketAcaoDto);

            //var ticketAcaoIncluidoDto = await TicketAcaoRepositorio.FindById(ticketAcaoIncluido.Codigo);

            //ticketAcaoIncluidoDto = Mapper.Map<TicketAcaoDto>(ticketAcaoIncluidoDto);
            var result = ticketAcaoIncluido;



            return result;
        }
        public async Task<TicketAcaoDto> AlterarTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            var result = await TicketAcaoMovService.AlterarTicketAcao(codTicket, ticketAcao);
            return result;
        }
        public async Task ExcluirTicketAcao(int codTicket, TicketAcaoDto ticketAcao)
        {
            await TicketAcaoMovService.ExcluirTicketAcao(codTicket, ticketAcao);
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
                var ticketAgrupamento = await TicketAgrupamentoMovService.InserirTicketOrigem(ticketModelOrigem.Id);

                //pegar idTicketAgrupamento
                var idTicketAgrupamento = ticketAgrupamento.CodigoAgrupamento;

                //inserir ticketRelacionamento (idTicket, e idTicketAgrupamento)
               await TicketRelacionamentoMovService.InserirRelacaoEntreTickets(idTicketAgrupamento, ticketModelVincular.Id);
            }
            catch (Exception)
            {

                throw;
            }
           

            var result = await base.FindByCodigo(ticketModelOrigem.Id);

            return result;
        }
    }
}
