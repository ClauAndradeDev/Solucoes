using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Empresa_EmpresaId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_EmpresaId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Pessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EmpresaId",
                table: "Pessoa",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Empresa_EmpresaId",
                table: "Pessoa",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
