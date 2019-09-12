using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
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
                    FornecedorId = table.Column<int>(nullable: true),
                    GrupoDeProdutoId = table.Column<int>(nullable: true),
                    SubGrupoDeProdutoId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 50, nullable: false),
                    UnidadeMedida = table.Column<string>(maxLength: 20, nullable: true),
                    Marca = table.Column<string>(maxLength: 20, nullable: true),
                    LocalNoEstoque = table.Column<string>(maxLength: 30, nullable: true),
                    Referencia = table.Column<string>(maxLength: 20, nullable: true),
                    Detalhe = table.Column<string>(maxLength: 150, nullable: true),
                    Caracteristicas = table.Column<string>(maxLength: 255, nullable: true),
                    DataUltimaCompra = table.Column<DateTime>(nullable: true),
                    DataUltimaVenda = table.Column<DateTime>(nullable: true),
                    PrecoCompra = table.Column<decimal>(nullable: false),
                    PrecoCusto = table.Column<decimal>(nullable: false),
                    PrecoMinimo = table.Column<decimal>(nullable: false),
                    PrecoVenda = table.Column<decimal>(nullable: false),
                    EstoqueMinimo = table.Column<decimal>(nullable: false),
                    EstoqueMedio = table.Column<decimal>(nullable: false),
                    Volume = table.Column<decimal>(nullable: false),
                    PesoLiquido = table.Column<decimal>(nullable: false),
                    Comissao = table.Column<decimal>(nullable: false),
                    NCM = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_GrupoDeProduto_GrupoDeProdutoId",
                        column: x => x.GrupoDeProdutoId,
                        principalTable: "GrupoDeProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_SubGrupoDeProduto_SubGrupoDeProdutoId",
                        column: x => x.SubGrupoDeProdutoId,
                        principalTable: "SubGrupoDeProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_GrupoDeProdutoId",
                table: "Produto",
                column: "GrupoDeProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SubGrupoDeProdutoId",
                table: "Produto",
                column: "SubGrupoDeProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
