using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solucoes.Api.App.Migrations
{
    /// <inheritdoc />
    public partial class EmpresaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetorEmpresa_Empresa_EmpresaId",
                table: "SetorEmpresa");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "SetorEmpresa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Empresa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmpresaPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaPessoas_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaPessoas_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaPessoas_EmpresaId",
                table: "EmpresaPessoas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaPessoas_PessoaId",
                table: "EmpresaPessoas",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetorEmpresa_Empresa_EmpresaId",
                table: "SetorEmpresa",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetorEmpresa_Empresa_EmpresaId",
                table: "SetorEmpresa");

            migrationBuilder.DropTable(
                name: "EmpresaPessoas");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Empresa");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "SetorEmpresa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SetorEmpresa_Empresa_EmpresaId",
                table: "SetorEmpresa",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
