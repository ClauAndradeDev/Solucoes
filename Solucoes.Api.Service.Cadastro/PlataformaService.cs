﻿using Solucoes.Api.Repositorios;
using Solucoes.Api.Service.Movimentacao;
using Solucoes.Modelo.Dtos;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Solucoes.Api.Service.Cadastro
{
    public class PlataformaService : CrudServices<Plataforma, PlataformaDto>
    {
        //public LogMovimentacaoService LogMovimentacaoService { get; set; }
        public PlataformaService(
                PlataformaRepositorio plataformaRepositorio,
                //LogMovimentacaoService logMovimentacaoService,
                Mapper.Mapper mapper) :
            base(plataformaRepositorio, mapper)
        {
           // LogMovimentacaoService = logMovimentacaoService;
        }

        public override async Task<PlataformaDto> Insert(PlataformaDto plataforma)
        {
            plataforma.DataCadastro = DateTime.Now;
            var plataformaDto = await base.Insert(plataforma);
            var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

            var result = await base.FindByCodigo(plataformaModel.Id);

            //var logMovPlataforma = await LogMovimentacaoService.InserirLogMov(plataformaModel, 1, "Plataforma", plataformaModel.Id);

            return result;
        }

        public override async Task<PlataformaDto> Update(int id, PlataformaDto plataforma)
        {

            var plataformaDto = await base.Update(id, plataforma);
            var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

            var result = await base.FindByCodigo(plataformaModel.Id);

            //var logMovUsuario = await LogMovimentacaoService.InserirLogMov(plataformaModel, 2, "Usuario", plataformaModel.Id);

            return result;
        }

        public override async Task Delete(int id)
        {
            var plataformaDto = await base.FindByCodigo(id);
            var plataformaModel = await base.ReturnModel(plataformaDto.Codigo);

            //var logMovUsuario = await LogMovimentacaoService.InserirLogMov(plataformaModel, 3, "Usuario", plataformaModel.Id);

            //if (logMovUsuario != null)
            //{
                await base.Delete(plataformaDto.Codigo);
            //}
            
        }
    }
}
