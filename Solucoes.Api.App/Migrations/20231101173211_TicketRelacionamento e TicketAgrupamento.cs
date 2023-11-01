using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class TicketRelacionamentoeTicketAgrupamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketAgrupamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAgrupamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAgrupamentos_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketRelacionamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    TicketAgrupamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRelacionamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketRelacionamentos_TicketAgrupamentos_TicketAgrupamentoId",
                        column: x => x.TicketAgrupamentoId,
                        principalTable: "TicketAgrupamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketRelacionamentos_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketAgrupamentos_TicketId",
                table: "TicketAgrupamentos",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelacionamentos_TicketAgrupamentoId",
                table: "TicketRelacionamentos",
                column: "TicketAgrupamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketRelacionamentos_TicketId",
                table: "TicketRelacionamentos",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketRelacionamentos");

            migrationBuilder.DropTable(
                name: "TicketAgrupamentos");
        }
    }
}
