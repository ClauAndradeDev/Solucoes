﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solucoes.Modelo.Contexto;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoContato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Contato", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPFCNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IEMunicipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeRazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RGIE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("SobreNomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoEmpresa")
                        .HasColumnType("int");

                    b.Property<bool?>("WhatsApp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.Property<int?>("TipoEndereco")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Acesso")
                        .HasColumnType("int");

                    b.Property<string>("CPFCNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeRazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerfilPessoa")
                        .HasColumnType("int");

                    b.Property<string>("RGIE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("SobreNomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<bool?>("WhatsApp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.PessoaEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("PessoaEmpresa", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Plataforma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Plataforma", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Setor", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroSequencial")
                        .HasColumnType("int");

                    b.Property<bool?>("Origem")
                        .HasColumnType("bit");

                    b.Property<int?>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.Property<int?>("TipoChamado")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketAcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAcao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TicketAcao");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketAgrupamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketAgrupamentos");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketRelacionamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TicketAgrupamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketAgrupamentoId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketRelacionamentos");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Contato", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Endereco", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.PessoaEmpresa", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Empresa", "Empresa")
                        .WithMany("PessoaEmpresas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Solucoes.Modelo.Entidades.Pessoa", "Pessoa")
                        .WithMany("PessoaEmpresas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Plataforma", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Empresa", "Empresa")
                        .WithMany("Plataformas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Setor", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Empresa", "Empresa")
                        .WithMany("Setores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Ticket", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Empresa", "Empresa")
                        .WithMany("Tickets")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Solucoes.Modelo.Entidades.Plataforma", "Plataforma")
                        .WithMany("Tickets")
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Empresa");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketAcao", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Ticket", "Ticket")
                        .WithMany("TicketAcoes")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Solucoes.Modelo.Entidades.Usuario", "Usuario")
                        .WithMany("TicketAcoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Ticket");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketAgrupamento", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketRelacionamento", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.TicketAgrupamento", "TicketAgrupamento")
                        .WithMany("TicketRelacionamentos")
                        .HasForeignKey("TicketAgrupamentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Solucoes.Modelo.Entidades.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");

                    b.Navigation("TicketAgrupamento");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Usuario", b =>
                {
                    b.HasOne("Solucoes.Modelo.Entidades.Pessoa", "Pessoa")
                        .WithMany("Usuarios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Empresa", b =>
                {
                    b.Navigation("PessoaEmpresas");

                    b.Navigation("Plataformas");

                    b.Navigation("Setores");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Pessoa", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");

                    b.Navigation("PessoaEmpresas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Plataforma", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Ticket", b =>
                {
                    b.Navigation("TicketAcoes");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.TicketAgrupamento", b =>
                {
                    b.Navigation("TicketRelacionamentos");
                });

            modelBuilder.Entity("Solucoes.Modelo.Entidades.Usuario", b =>
                {
                    b.Navigation("TicketAcoes");
                });
#pragma warning restore 612, 618
        }
    }
}
