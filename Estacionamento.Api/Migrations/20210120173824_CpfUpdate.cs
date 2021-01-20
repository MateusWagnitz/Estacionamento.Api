using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Api.Migrations
{
    public partial class CpfUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CpfId",
                table: "Patio",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CpfId",
                table: "Cliente",
                newName: "Cpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Patio",
                newName: "CpfId");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Cliente",
                newName: "CpfId");
        }
    }
}
