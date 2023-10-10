using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<AgendamentoItem> AgendamentoItems { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<ChamadoItem> ChamadoItems { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaEndereco> PessoaEnderecos { get; set; }
        public DbSet<SetorEmpresa> SetorEmpresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
