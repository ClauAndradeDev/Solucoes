using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class InclusãoReuniãoEReuniãoAção : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reunioes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrevisaoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraAgendamentoInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraAgendamentoFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunioes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunioes_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reunioes_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReuniaoAcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataPrevisaoRetorno = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReuniaoId = table.Column<int>(type: "int", nullable: true),
                    SetorId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReuniaoAcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReuniaoAcoes_Reunioes_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reunioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReuniaoAcoes_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReuniaoAcoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReuniaoAcoes_ReuniaoId",
                table: "ReuniaoAcoes",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReuniaoAcoes_SetorId",
                table: "ReuniaoAcoes",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReuniaoAcoes_UsuarioId",
                table: "ReuniaoAcoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_EmpresaId",
                table: "Reunioes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_TicketId",
                table: "Reunioes",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReuniaoAcoes");

            migrationBuilder.DropTable(
                name: "Reunioes");
        }
    }
}
