using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class AlteraçãoEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Empresa_EmpresaId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_EmpresaId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Endereco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EmpresaId",
                table: "Endereco",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Empresa_EmpresaId",
                table: "Endereco",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
