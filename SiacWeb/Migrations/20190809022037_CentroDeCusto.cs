using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class CentroDeCusto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentroDeCusto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    TipoDePessoa = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 80, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    IE = table.Column<string>(maxLength: 20, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Whatsapp = table.Column<string>(maxLength: 20, nullable: true),
                    Telegram = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Site = table.Column<string>(maxLength: 100, nullable: true),
                    Facebook = table.Column<string>(maxLength: 100, nullable: true),
                    Endereco_TipoDeLogradouro = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 150, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_UF = table.Column<string>(maxLength: 2, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Telefone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroDeCusto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroDeCusto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroDeCusto_EmpresaId",
                table: "CentroDeCusto",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentroDeCusto");
        }
    }
}
