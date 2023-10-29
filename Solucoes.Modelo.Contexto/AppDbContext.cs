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

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
       
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaEmpresa> PessoaEmpresa { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        //public DbSet<Reuniao> Reunioes { get; set; }
        //public DbSet<ReuniaoAcao> ReuniaoAcao { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketAcao> TicketAcaos { get; set; }
        public DbSet<TicketAgrupamento> TicketAgrupamentos { get; set; }
        public DbSet<TicketRelacionamento> TicketRelacionamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //public DbSet<LogMovimentacao> LogMovimentacoes { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contato
            modelBuilder.Entity<Contato>()
               .ToTable("Contato");

            modelBuilder.Entity<Contato>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contato>()
               .Property(c => c.DataCadastro);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Situacao);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Nome);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Telefone);

            modelBuilder.Entity<Contato>()
                .Property(c => c.Email);

            modelBuilder.Entity<Contato>()
                .Property(c => c.TipoContato);

            #endregion

            #region Empresa
            modelBuilder.Entity<Empresa>()
                .ToTable("Empresa");

            modelBuilder.Entity<Empresa>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Empresa>()
                .Property(e => e.DataCadastro);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Setores)
                .WithOne(s => s.Empresa)
                .HasForeignKey(s => s.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Plataformas)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.PessoaEmpresas)
                .WithOne(pe => pe.Empresa)
                .HasForeignKey(pe => pe.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Tickets)
                .WithOne(t => t.Empresa)
                .HasForeignKey(t => t.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Endereço
            modelBuilder.Entity<Endereco>()
               .ToTable("Endereco");

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Endereco>()
               .Property(e => e.DataCadastro);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Situacao);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Numero);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Bairro);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Estado);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.TipoEndereco);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.PessoaId);
            #endregion

            #region Pessoa
            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa");

            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataCadastro);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Situacao);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.NomeRazaoSocial);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.SobreNomeFantasia);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.CPFCNPJ);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.RGIE);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataNascimento);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Email);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Telefone);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.WhatsApp);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.TipoPessoa);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.PerfilPessoa);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.Acesso);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Enderecos)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Contatos)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(c => c.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Usuarios)
                .WithOne(u => u.Pessoa)
                .HasForeignKey(u => u.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.PessoaEmpresas)
                .WithOne(pe => pe.Pessoa)
                .HasForeignKey(pe => pe.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region PessoaEmpresa
            modelBuilder.Entity<PessoaEmpresa>()
               .ToTable("PessoaEmpresa");

            modelBuilder.Entity<PessoaEmpresa>()
                .HasKey(pe => pe.Id);

            modelBuilder.Entity<PessoaEmpresa>()
                .Property(pe => pe.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PessoaEmpresa>()
                .Property(pe => pe.DataCadastro);

            modelBuilder.Entity<PessoaEmpresa>()
                .Property(pe => pe.Situacao);

            modelBuilder.Entity<PessoaEmpresa>()
                .Property(pe => pe.PessoaId);

            modelBuilder.Entity<PessoaEmpresa>()
                .Property(pe => pe.EmpresaId);
            #endregion

            #region Plataforma
            modelBuilder.Entity<Plataforma>()
               .ToTable("Plataforma");

            modelBuilder.Entity<Plataforma>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Plataforma>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Plataforma>()
                .Property(p => p.DataCadastro);

            modelBuilder.Entity<Plataforma>()
                .Property(p => p.Situacao);

            modelBuilder.Entity<Plataforma>()
                .Property(p => p.Descricao);

            modelBuilder.Entity<Plataforma>()
                .Property(p => p.EmpresaId);
            #endregion

            #region Setor
            modelBuilder.Entity<Setor>()
                .ToTable("Setor");

            modelBuilder.Entity<Setor>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Setor>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Setor>()
                .Property(s => s.DataCadastro);

            modelBuilder.Entity<Setor>()
                .Property(s => s.Situacao);

            modelBuilder.Entity<Setor>()
                .Property(s => s.Descricao);

            modelBuilder.Entity<Setor>()
                .Property(s => s.EmpresaId);
            #endregion

            #region Ticket
            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Titulo);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.EmpresaId);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.PlataformaId);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketAgrupamentos)
                .WithOne(ta => ta.Ticket)
                .HasForeignKey(ta => ta.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.TicketRelacionamentos)
                .WithOne(tr => tr.Ticket)
                .HasForeignKey(tr => tr.TicketId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region TicketAgrupamento
            modelBuilder.Entity<TicketAgrupamento>()
                .HasKey(ta => ta.Id);

            modelBuilder.Entity<TicketAgrupamento>()
                .Property(ta => ta.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TicketAgrupamento>()
                .Property(ta => ta.TicketId);

            modelBuilder.Entity<TicketAgrupamento>()
                .HasMany(ta => ta.TicketRelacionamentos)
                .WithOne(tr => tr.TicketAgrupamento)
                .HasForeignKey(tr => tr.TicketAgrupamentoId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region TicketRelacionamento
            modelBuilder.Entity<TicketRelacionamento>()
               .HasKey(ta => ta.Id);

            modelBuilder.Entity<TicketRelacionamento>()
                .Property(ta => ta.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TicketRelacionamento>()
                .Property(ta => ta.TicketId);

            modelBuilder.Entity<TicketRelacionamento>()
               .Property(ta => ta.TicketAgrupamentoId);
            #endregion

            #region Usuario
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario");

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.DataCadastro);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Situacao);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Login);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.PessoaId);
            #endregion


            base.OnModelCreating(modelBuilder);
        }
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
