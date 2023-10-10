using Microsoft.EntityFrameworkCore;
using Solucoes.Modelo.Contexto;
using Solucoes.Modelo.Entidades;
using Solucoes.Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Solucoes.Modelo.Dtos;
using System.Text.Json;

namespace Solucoes.Api.Repositorios
{
    public class LogMovimentacaoRepositorio : BaseRepositorio<LogMovimentacao>
    {
        public LogMovimentacaoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
