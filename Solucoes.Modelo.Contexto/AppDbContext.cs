using Microsoft.EntityFrameworkCore;
using Solucoes.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Contexto
{
    public class AppDbContext : DbContext
    {
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<ChamadoItem> ChamdoItems { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<ReuniaoItem> ReuniaoItems { get; set; }
        public DbSet<SetorEmpresa> SetorEmpresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EmpresaPessoas> EmpresaPessoas { get; set; }
        //public DbSet<LogMovimentacao> LogMovimentacoes { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(ObterStringConexao());
        //        base.OnConfiguring(optionsBuilder);
        //    }

        //    optionsBuilder.UseLazyLoadingProxies();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }



        public string ObterStringConexao()
        {
            return "Data Source=DESKTOP-IO0A64E\\SQLEXPRESS;Initial Catalog=SolucoesDb;User Id=sa;Password=@Itapoa2023;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                //"Server=DESKTOP-IO0A64E\\SQLEXPRESS;Database=SolucoesDb;User Id=sa;Password=@Itapoa2023;Trusted_Connection=True;TrustServerCertificate=True";
        }


        internal Task FindAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
