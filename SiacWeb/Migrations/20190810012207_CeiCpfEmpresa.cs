using Microsoft.EntityFrameworkCore.Migrations;

namespace SiacWeb.Migrations
{
    public partial class CeiCpfEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CnpjBase",
                table: "Empresa",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "CEI",
                table: "Empresa",
                maxLength: 12,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Empresa",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IE",
                table: "CentroDeCusto",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IM",
                table: "CentroDeCusto",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEI",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "IM",
                table: "CentroDeCusto");

            migrationBuilder.AlterColumn<string>(
                name: "CnpjBase",
                table: "Empresa",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IE",
                table: "CentroDeCusto",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}
