using Microsoft.IdentityModel.Abstractions;
using Solucoes.Api.Repositorios;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Movimentacao
{
    public class ReuniaoAcaoService: CrudServices<ReuniaoAcao, ReuniaoAcaoDto>
    {
        public ReuniaoRepositorio ReuniaoRepositorio { get; set; }
        public SetorRepositorio SetorRepositorio { get; set; }
        public UsuarioRepositorio UsuarioRepositorio { get;set; }
        public TicketRepositorio TicketRepositorio { get; set; }

        public ReuniaoAcaoService(
                        ReuniaoAcaoRepositorio reuniaoAcaoRepositorio, 
                        ReuniaoRepositorio reuniaoRepositorio,
                        SetorRepositorio setorRepositorio,
                        UsuarioRepositorio usuarioRepositorio,
                        TicketRepositorio ticketRepositorio, 
                        Mapper.Mapper mapper): 
            base (reuniaoAcaoRepositorio, mapper)
        {
            ReuniaoRepositorio = reuniaoRepositorio;
            SetorRepositorio = setorRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            TicketRepositorio = ticketRepositorio;
        }

        public async Task<ReuniaoAcaoDto> InserirAcaoReuniao(int codigo, int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var ticketModel = await TicketRepositorio.FindById(codigo);
            var reuniaoModel = await ReuniaoRepositorio.FindById(codReuniao);
            var usuarioModel = await UsuarioRepositorio.FindById(reuniaoAcao.Usuario.Codigo);
            var setorModel = await SetorRepositorio.FindById(reuniaoAcao.Setor.Codigo);

            var reuniaoAcaoAdd = Mapper.Map<ReuniaoAcao>(reuniaoAcao);

            if (ticketModel is not null)
            {
                if(reuniaoModel.TicketId.Equals(ticketModel.Id))
                {
                   if(usuarioModel is not null)
                    {
                        if(setorModel is not null)
                        {
                            reuniaoAcaoAdd.ReuniaoId = reuniaoModel.Id;
                            reuniaoAcaoAdd.UsuarioId = usuarioModel.Id;
                            reuniaoAcaoAdd.SetorId = setorModel.Id;
                            reuniaoAcaoAdd.Reuniao = null;
                            reuniaoAcaoAdd.Usuario = null;
                            reuniaoAcaoAdd.Setor = null;

                            reuniaoAcaoAdd = await Repositorio.Add(reuniaoAcaoAdd);
                        }
                    }
                }
            }

            var result = await base.FindByCodigo(reuniaoAcaoAdd.Id);
            return result;
        }

        public async Task<ReuniaoAcaoDto> AlterarAcaoReuniao(int codTicket,int codReuniao,  ReuniaoAcaoDto reuniaoAcao)
        {
            var reuniaoModel = await ReuniaoRepositorio.FindById(codReuniao);
            var usuarioModel = await UsuarioRepositorio.FindById(reuniaoAcao.Usuario.Codigo);
            var setorModel = await SetorRepositorio.FindById(reuniaoAcao.Setor.Codigo);

            var reuniaoAcaoModelBanco = await Repositorio.FindById(reuniaoAcao.Codigo);
            

            if(reuniaoModel is not null)
            {
                if(usuarioModel is not null)
                {
                    if (!reuniaoAcaoModelBanco.SetorId.Equals(setorModel.Id))
                    {
                        //alterou o setor
                        reuniaoAcaoModelBanco.SetorId = setorModel.Id;
                    }
                    reuniaoAcaoModelBanco.Titulo = reuniaoAcao.Titulo;
                    reuniaoAcaoModelBanco.Conteudo = reuniaoAcao.Conteudo;
                    reuniaoAcaoModelBanco.DataPrevisaoRetorno = reuniaoAcao.DataPrevisaoRetorno;
                    reuniaoAcaoModelBanco.HoraInicial = reuniaoAcao.HoraInicial;
                    reuniaoAcaoModelBanco.HoraFinal = reuniaoAcao.HoraFinal;
                    reuniaoAcaoModelBanco = await Repositorio.Replace(reuniaoAcaoModelBanco.Id, reuniaoAcaoModelBanco);
                }
            }



            //var reuniaoAcaoAlterar = Mapper.Map<ReuniaoAcao>(reuniaoAcao);
            //var alterouSetor = reuniaoAcaoAlterar.Setor.Id.Equals(setorModel.Id);
            //if (reuniaoModel is not null)
            //{
            //    if(usuarioModel is not null)
            //    {
            //        if (!alterouSetor)
            //        {
            //            reuniaoAcaoAlterar.SetorId = setorModel.Id;
            //        }
            //        reuniaoAcaoAlterar = await Repositorio.Replace(reuniaoAcaoAlterar.Id, reuniaoAcaoAlterar);
            //    }
            //}
            
            var result = await base.FindByCodigo(reuniaoAcaoModelBanco.Id);

            return result;  

        }

        public async Task ExcluirAcaoReuniao(int codReuniao, ReuniaoAcaoDto reuniaoAcao)
        {
            var reuniaoModel = await ReuniaoRepositorio.FindById(codReuniao);
            var reuniaoAcaoModelExcluir = Mapper.Map<ReuniaoAcao>(reuniaoAcao);
            var listaReuniaoAcao = await Repositorio.All();
            if(listaReuniaoAcao.Count() == 1)
            {
                //não excluir retornar mensagem
                //deve solicitar a exclusão do ticket todo.
            }
            else
            {
                //existem outras ações, pode remover a selecionada
                foreach (var item in listaReuniaoAcao)
                {
                    if (item.Id == reuniaoAcaoModelExcluir.Id)
                    {
                        await Repositorio.Remove(reuniaoAcaoModelExcluir.Id);
                    }
                }
            }          
        }

        public async Task ExcluirAcaoReuniaoViaReuniao(int codReuniao, int codReuniaoAcao)
        {
            var reuniaoAexcluir = await ReuniaoRepositorio.FindById(codReuniao);
            var reuniaoAcaoAexcluir = await Repositorio.FindById(codReuniaoAcao);
            if (reuniaoAexcluir is not null)
            {
                if(reuniaoAcaoAexcluir is not null)
                {
                    await Repositorio.Remove(reuniaoAcaoAexcluir.Id);
                }
            }
            
        }

        public async Task<ReuniaoDto> BuscarReuniaoPorReuniaoAcao(int codReuniaoAcao)
        {
            var reuniaoAcao = await Repositorio.FindById(codReuniaoAcao);
            var reuniaoId = reuniaoAcao.Reuniao.Id;
            var reunioes = await ReuniaoRepositorio.FindById(reuniaoId);

            var reuniaoDto = Mapper.Map<ReuniaoDto>(reunioes);

            return reuniaoDto;
            
        }

        public async Task<ReuniaoAcaoReuniaoDto[]> BuscarReuniaoAcaoPorReuniao(int codReuniao)
        {
            var reuniaoModel = await ReuniaoRepositorio.FindById(codReuniao);
            var reuniaoAcoes = reuniaoModel.ReuniaoAcoes;
            reuniaoAcoes ??= new ReuniaoAcao[] { };

            //var reuniaoAcaoModel = reuniaoModel.ReuniaoAcoes;

            //var result = Mapper.Map<ReuniaoAcaoDto>(reuniaoAcaoModel);
            var result = Mapper.Map<ReuniaoAcaoReuniaoDto[]>(reuniaoAcoes);
            return result;
        }

    }
}
