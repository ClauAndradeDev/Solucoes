using Microsoft.EntityFrameworkCore;
using Modelo.Contexto;
using Modelo.Entidades;
using Modelo.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class EnderecoRepositorio : BaseRepositorios<Endereco>
    {
        public EnderecoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
