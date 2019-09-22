using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class Inventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventario",
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
                    EmpresaId = table.Column<int>(nullable: true),
                    CentroDeCustoId = table.Column<int>(nullable: false),
                    DataProcessamento = table.Column<DateTime>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventario_CentroDeCusto_CentroDeCustoId",
                        column: x => x.CentroDeCustoId,
                        principalTable: "CentroDeCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioItem",
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
                    EmpresaId = table.Column<int>(nullable: true),
                    CentroDeCustoId = table.Column<int>(nullable: false),
                    InventarioId = table.Column<int>(nullable: true),
                    ProdutoId = table.Column<int>(nullable: true),
                    QuantidadeSistema = table.Column<double>(nullable: false),
                    QuantidadeInformada = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioItem_CentroDeCusto_CentroDeCustoId",
                        column: x => x.CentroDeCustoId,
                        principalTable: "CentroDeCusto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioItem_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioItem_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_CentroDeCustoId",
                table: "Inventario",
                column: "CentroDeCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_EmpresaId",
                table: "Inventario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_FuncionarioId",
                table: "Inventario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioItem_CentroDeCustoId",
                table: "InventarioItem",
                column: "CentroDeCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioItem_EmpresaId",
                table: "InventarioItem",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioItem_InventarioId",
                table: "InventarioItem",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioItem_ProdutoId",
                table: "InventarioItem",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioItem");

            migrationBuilder.DropTable(
                name: "Inventario");
        }
    }
}
