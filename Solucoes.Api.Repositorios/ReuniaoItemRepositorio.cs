﻿using Microsoft.EntityFrameworkCore;
using Solucoes.Modelo.Contexto;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Api.Repositorios
{
    public class ReuniaoItemRepositorio : BaseRepositorio<ReuniaoAcao>
    {
        public ReuniaoItemRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
