using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class DescricaoGrupoDeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "GrupoDeProduto",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "GrupoDeProduto",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
