using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Api.Migrations
{
    public partial class carroId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patio",
                table: "Patio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carro",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "Id_Carro",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Patio_Id",
                table: "Patio");

            migrationBuilder.DropColumn(
                name: "Carro_Id",
                table: "Carro");

            migrationBuilder.RenameColumn(
                name: "Id_Ticket",
                table: "Ticket",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Cpf_Id",
                table: "Patio",
                newName: "CpfId");

            migrationBuilder.RenameColumn(
                name: "Cpf_Id",
                table: "Cliente",
                newName: "CpfId");

            migrationBuilder.AddColumn<string>(
                name: "CarroId",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatioId",
                table: "Patio",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "carroId",
                table: "Carro",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patio",
                table: "Patio",
                column: "PatioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carro",
                table: "Carro",
                column: "carroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Patio",
                table: "Patio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carro",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "CarroId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PatioId",
                table: "Patio");

            migrationBuilder.DropColumn(
                name: "carroId",
                table: "Carro");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Ticket",
                newName: "Id_Ticket");

            migrationBuilder.RenameColumn(
                name: "CpfId",
                table: "Patio",
                newName: "Cpf_Id");

            migrationBuilder.RenameColumn(
                name: "CpfId",
                table: "Cliente",
                newName: "Cpf_Id");

            migrationBuilder.AddColumn<string>(
                name: "Id_Carro",
                table: "Ticket",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Patio_Id",
                table: "Patio",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Carro_Id",
                table: "Carro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patio",
                table: "Patio",
                column: "Patio_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carro",
                table: "Carro",
                column: "Carro_Id");
        }
    }
}
