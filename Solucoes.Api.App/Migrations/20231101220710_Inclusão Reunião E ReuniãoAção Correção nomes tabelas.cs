using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class InclusãoReuniãoEReuniãoAçãoCorreçãonomestabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcoes_Reunioes_ReuniaoId",
                table: "ReuniaoAcoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcoes_Setor_SetorId",
                table: "ReuniaoAcoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcoes_Usuario_UsuarioId",
                table: "ReuniaoAcoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_Empresa_EmpresaId",
                table: "Reunioes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_Ticket_TicketId",
                table: "Reunioes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reunioes",
                table: "Reunioes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReuniaoAcoes",
                table: "ReuniaoAcoes");

            migrationBuilder.RenameTable(
                name: "Reunioes",
                newName: "Reuniao");

            migrationBuilder.RenameTable(
                name: "ReuniaoAcoes",
                newName: "ReuniaoAcao");

            migrationBuilder.RenameIndex(
                name: "IX_Reunioes_TicketId",
                table: "Reuniao",
                newName: "IX_Reuniao_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Reunioes_EmpresaId",
                table: "Reuniao",
                newName: "IX_Reuniao_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcoes_UsuarioId",
                table: "ReuniaoAcao",
                newName: "IX_ReuniaoAcao_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcoes_SetorId",
                table: "ReuniaoAcao",
                newName: "IX_ReuniaoAcao_SetorId");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcoes_ReuniaoId",
                table: "ReuniaoAcao",
                newName: "IX_ReuniaoAcao_ReuniaoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reuniao",
                table: "Reuniao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReuniaoAcao",
                table: "ReuniaoAcao",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reuniao_Empresa_EmpresaId",
                table: "Reuniao",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reuniao_Ticket_TicketId",
                table: "Reuniao",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcao_Reuniao_ReuniaoId",
                table: "ReuniaoAcao",
                column: "ReuniaoId",
                principalTable: "Reuniao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcao_Setor_SetorId",
                table: "ReuniaoAcao",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcao_Usuario_UsuarioId",
                table: "ReuniaoAcao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reuniao_Empresa_EmpresaId",
                table: "Reuniao");

            migrationBuilder.DropForeignKey(
                name: "FK_Reuniao_Ticket_TicketId",
                table: "Reuniao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcao_Reuniao_ReuniaoId",
                table: "ReuniaoAcao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcao_Setor_SetorId",
                table: "ReuniaoAcao");

            migrationBuilder.DropForeignKey(
                name: "FK_ReuniaoAcao_Usuario_UsuarioId",
                table: "ReuniaoAcao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReuniaoAcao",
                table: "ReuniaoAcao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reuniao",
                table: "Reuniao");

            migrationBuilder.RenameTable(
                name: "ReuniaoAcao",
                newName: "ReuniaoAcoes");

            migrationBuilder.RenameTable(
                name: "Reuniao",
                newName: "Reunioes");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcao_UsuarioId",
                table: "ReuniaoAcoes",
                newName: "IX_ReuniaoAcoes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcao_SetorId",
                table: "ReuniaoAcoes",
                newName: "IX_ReuniaoAcoes_SetorId");

            migrationBuilder.RenameIndex(
                name: "IX_ReuniaoAcao_ReuniaoId",
                table: "ReuniaoAcoes",
                newName: "IX_ReuniaoAcoes_ReuniaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Reuniao_TicketId",
                table: "Reunioes",
                newName: "IX_Reunioes_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Reuniao_EmpresaId",
                table: "Reunioes",
                newName: "IX_Reunioes_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReuniaoAcoes",
                table: "ReuniaoAcoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reunioes",
                table: "Reunioes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcoes_Reunioes_ReuniaoId",
                table: "ReuniaoAcoes",
                column: "ReuniaoId",
                principalTable: "Reunioes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcoes_Setor_SetorId",
                table: "ReuniaoAcoes",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReuniaoAcoes_Usuario_UsuarioId",
                table: "ReuniaoAcoes",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_Empresa_EmpresaId",
                table: "Reunioes",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_Ticket_TicketId",
                table: "Reunioes",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id");
        }
    }
}
