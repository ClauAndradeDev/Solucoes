using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class AjustetabelaTicketAcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Plataforma_PlataformaId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketRelacionamentos");

            migrationBuilder.DropTable(
                name: "TicketAgrupamento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAlteracao",
                table: "TicketAcao",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAcao_TicketId",
                table: "TicketAcao",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAcao_UsuarioId",
                table: "TicketAcao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Plataforma_PlataformaId",
                table: "Ticket",
                column: "PlataformaId",
                principalTable: "Plataforma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAcao_Ticket_TicketId",
                table: "TicketAcao",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAcao_Usuario_UsuarioId",
                table: "TicketAcao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Plataforma_PlataformaId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAcao_Ticket_TicketId",
                table: "TicketAcao");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAcao_Usuario_UsuarioId",
                table: "TicketAcao");

            migrationBuilder.DropIndex(
                name: "IX_TicketAcao_TicketId",
                table: "TicketAcao");

            migrationBuilder.DropIndex(
                name: "IX_TicketAcao_UsuarioId",
                table: "TicketAcao");

            migrationBuilder.DropColumn(
                name: "DataUltimaAlteracao",
                table: "TicketAcao");

            migrationBuilder.CreateTable(
                name: "TicketAgrupamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAgrupamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAgrupamento_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketRelacionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketAgrupamentoId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRelacionamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketRelacionamentos_TicketAgrupamento_TicketAgrupamentoId",
                        column: x => x.TicketAgrupamentoId,
                        principalTable: "TicketAgrupamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketRelacionamentos_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAgrupamento_TicketId",
                table: "TicketAgrupamento",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelacionamentos_TicketAgrupamentoId",
                table: "TicketRelacionamentos",
                column: "TicketAgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelacionamentos_TicketId",
                table: "TicketRelacionamentos",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Plataforma_PlataformaId",
                table: "Ticket",
                column: "PlataformaId",
                principalTable: "Plataforma",
                principalColumn: "Id");
        }
    }
}
