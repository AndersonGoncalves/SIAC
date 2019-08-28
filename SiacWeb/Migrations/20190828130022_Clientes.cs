using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DadosBancarios_AutonomoId",
                table: "Autonomo");

            migrationBuilder.CreateTable(
                name: "Cliente",
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
                    TipoDePessoa = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 80, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 50, nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    IE = table.Column<string>(maxLength: 14, nullable: true),
                    IM = table.Column<string>(maxLength: 20, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Whatsapp = table.Column<string>(maxLength: 20, nullable: true),
                    Telegram = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Site = table.Column<string>(maxLength: 100, nullable: true),
                    Facebook = table.Column<string>(maxLength: 100, nullable: true),
                    Instagram = table.Column<string>(maxLength: 100, nullable: true),
                    NomeMae = table.Column<string>(maxLength: 80, nullable: true),
                    NomePai = table.Column<string>(maxLength: 80, nullable: true),
                    Endereco_TipoDeLogradouro = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Logradouro = table.Column<string>(maxLength: 150, nullable: true),
                    Endereco_Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_UF = table.Column<string>(maxLength: 2, nullable: true),
                    Endereco_Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Endereco_CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Endereco_Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    DadosBancarios_CodigoBanco = table.Column<string>(maxLength: 10, nullable: true),
                    DadosBancarios_Agencia = table.Column<string>(maxLength: 10, nullable: true),
                    DadosBancarios_Conta = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EmpresaId",
                table: "Cliente",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "DadosBancarios_AutonomoId",
                table: "Autonomo",
                nullable: false,
                defaultValue: 0);
        }
    }
}
