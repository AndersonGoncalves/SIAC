using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class GrupoDeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoDeProduto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: true),
                    Usuario = table.Column<string>(maxLength: 256, nullable: true),
                    Maquina = table.Column<string>(maxLength: 256, nullable: true),
                    EmUso = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoDeProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoDeProduto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoDeProduto_EmpresaId",
                table: "GrupoDeProduto",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoDeProduto");
        }
    }
}
