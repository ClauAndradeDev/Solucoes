using Castle.Components.DictionaryAdapter.Xml;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Movimentacao
{
    public class ReuniaoService : CrudServices<Reuniao, ReuniaoDto>
    {
        public TicketRepositorio TicketRepositorio { get; set; }
        public EmpresaRepositorio EmpresaRepositorio { get; set; }
        public ReuniaoAcaoService ReuniaoAcaoService { get; set; }
        public ReuniaoAcaoRepositorio ReuniaoAcaoRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get; set; }
        public SetorRepositorio SetorRepositorio { get; set; }

        public ReuniaoService(ReuniaoRepositorio reuniaoRepositorio,
                            TicketRepositorio ticketRepositorio,
                            EmpresaRepositorio empresaRepositorio,
                            ReuniaoAcaoService reuniaoAcaoService,
                            ReuniaoAcaoRepositorio reuniaoAcaoRepositorio,
                            UsuarioRepositorio usuarioRepositorio,
                            SetorRepositorio setorRepositorio,
                            Mapper.Mapper mapper) : base(reuniaoRepositorio, mapper)
        {
            TicketRepositorio = ticketRepositorio;
            EmpresaRepositorio = empresaRepositorio;
            ReuniaoAcaoService = reuniaoAcaoService;
            ReuniaoAcaoRepositorio = reuniaoAcaoRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            SetorRepositorio = setorRepositorio;
        }

        public async Task<ReuniaoDto> InserirReuniao(int codigo, ReuniaoDto reuniao)
        {
            var ticketModel = await TicketRepositorio.FindById(codigo);
            var empresaModel = await EmpresaRepositorio.FindById(reuniao.Empresa.Codigo);
            var reuniaoAcaoDaReuniao = reuniao.ReuniaoAcoes;
            var reuniaoModel = Mapper.Map<Reuniao>(reuniao);
            var reuniaoAcaoModel = new ReuniaoAcao();

            reuniaoModel.EmpresaId = empresaModel.Id;

            reuniaoModel.TicketId = ticketModel.Id;
            var result = new ReuniaoDto();


            if (ticketModel is not null)
            {
                if (empresaModel is not null)
                {
                    reuniaoModel.Empresa = null;
                    reuniaoModel.EmpresaId = empresaModel.Id;
                    reuniaoModel.DataAlteracao = DateTime.Now;
                    reuniaoModel.Situacao = SituacaoMovimentacaoEnum.Novo;
                    reuniaoModel.Ticket = null;
                    reuniaoModel.TicketId = ticketModel.Id;

                    /*Insiro Reunião*/
                    reuniaoModel = await Repositorio.Add(reuniaoModel);

                    if (reuniaoAcaoDaReuniao is not null)
                    {
                        var reuniaoAcaoInserir = reuniaoAcaoDaReuniao[0];

                        var usuarioModel = await UsuarioRepositorio.FindById(reuniaoAcaoInserir.Usuario.Codigo);
                        var setorModel = await SetorRepositorio.FindById(reuniaoAcaoInserir.Setor.Codigo);

                        var reuniaoAcaoInserirModel = Mapper.Map<ReuniaoAcao>(reuniaoAcaoInserir);
                        reuniaoAcaoInserirModel.UsuarioId = reuniaoAcaoInserir.Usuario.Codigo;
                        reuniaoAcaoInserirModel.SetorId = reuniaoAcaoInserir.Setor.Codigo;

                        var reuniaoAcaoDto = Mapper.Map<ReuniaoAcaoDto>(reuniaoAcaoInserirModel);
                        /*Insiro ReuniãoAção*/
                        reuniaoAcaoDto.Setor = Mapper.Map<SetorDto>(setorModel);
                        reuniaoAcaoDto.Usuario = Mapper.Map<UsuarioDto>(usuarioModel);
                        await ReuniaoAcaoService.InserirAcaoReuniao(ticketModel.Id, reuniaoModel.Id, reuniaoAcaoDto);

                        result = await base.FindByCodigo(reuniaoModel.Id);
                    }
                }
            }

            return result;

        }

        public async Task<ReuniaoDto> AlterarReuniao(int codigo, ReuniaoDto reuniao)
        {
            var reuniaoModelBanco = await Repositorio.FindById(reuniao.Codigo);
            var ticketModel = await TicketRepositorio.FindById(codigo);
            var reuniaoModelAlterado = Mapper.Map<Reuniao>(reuniao);
            var empresaModel = await EmpresaRepositorio.FindById(reuniao.Empresa.Codigo);

            if (reuniaoModelAlterado is not null)
            {
                if (reuniaoModelBanco is not null)
                {
                    if (ticketModel is not null)
                    {
                        if (empresaModel is not null)
                        {
                            if (reuniaoModelAlterado.Id.Equals(reuniaoModelBanco.Id))
                            {
                                reuniaoModelAlterado.DataAlteracao = DateTime.Now;
                                if (reuniaoModelAlterado.Situacao is null)
                                {
                                    reuniaoModelAlterado.Situacao = SituacaoMovimentacaoEnum.Novo;
                                }

                                reuniaoModelAlterado = await Repositorio.Add(reuniaoModelAlterado);
                            }
                        }
                    }
                }
            }
            var result = await base.FindByCodigo(reuniaoModelAlterado.Id);
            return result;

        }

        public async Task ExcluirReuniao(int codigo, int codReuniao)
        {
            //só verifico se tem ReuniaoAcao vinculado.

            var ticketModel = await TicketRepositorio.FindById(codigo);
            var reuniaoModel = await Repositorio.FindById(codReuniao);
            if (ticketModel is not null)
            {
                if (reuniaoModel is not null)
                {
                    var reuniaoAcaoExistentes = await ReuniaoAcaoService.BuscarReuniaoAcaoPorReuniao(codReuniao);
                    var listaReuniaoAcao = await ReuniaoAcaoRepositorio.All();


                    //se existir pelo menos 1 ReuniaoAcao
                    foreach (var item in reuniaoAcaoExistentes.ToArray())
                    {
                        foreach (var item1 in listaReuniaoAcao)
                        {
                            if (item.Codigo == item1.Id)
                            {
                                await ReuniaoAcaoService.ExcluirAcaoReuniaoViaReuniao(reuniaoModel.Id, item.Codigo);
                            }
                        }
                    }

                    await Repositorio.Remove(reuniaoModel.Id);

                }
            }


            /*
             * TO DO = Ajustar ao excluir Ticket para verificar sem tem reunião, se tiver não permite a exclusão
             */
        }

        public async Task<ReuniaoTicketDto[]> BuscarReuniaoPorTicket(int codTicket)
        {
            var ticket = await TicketRepositorio.FindById(codTicket);
            var reunioes = ticket.Reunioes;
            reunioes ??= new Reuniao[] { };

            var result = Mapper.Map<ReuniaoTicketDto[]>(reunioes);
            return result;
        }

        //Rotas de Alteração e Exclusão de ReuniãoAção
        public async Task<ReuniaoAcaoDto> AlterarAcaoReuniao(int codTicket, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await ReuniaoAcaoService.AlterarAcaoReuniao(codTicket, codReuniao, reuniaoAcao);
            return result;
        }

        public async Task<ReuniaoAcaoDto> InserirNovaAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var result = await ReuniaoAcaoService.InserirAcaoReuniao(codigo, codReuniao, reuniaoAcao);
            return result;
        }

        public async Task ExcluirAcaoReuniao(int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            await ReuniaoAcaoService.ExcluirAcaoReuniao(codReuniao, reuniaoAcao);
        }
    }
}
