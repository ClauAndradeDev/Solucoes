using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class PlataformaVinculocomEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Plataforma",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "WhatsApp",
                table: "Empresa",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Plataforma_EmpresaId",
                table: "Plataforma",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plataforma_Empresa_EmpresaId",
                table: "Plataforma",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plataforma_Empresa_EmpresaId",
                table: "Plataforma");

            migrationBuilder.DropIndex(
                name: "IX_Plataforma_EmpresaId",
                table: "Plataforma");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Plataforma");

            migrationBuilder.AlterColumn<bool>(
                name: "WhatsApp",
                table: "Empresa",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
