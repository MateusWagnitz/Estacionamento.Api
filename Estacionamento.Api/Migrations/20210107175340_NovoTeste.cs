using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Api.Migrations
{
    public partial class NovoTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteId_Cpf",
                table: "Carros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClienteNome",
                table: "Carros",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cpf = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    StatusCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => new { x.Id_Cpf, x.Nome });
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id_Ticket = table.Column<string>(nullable: false),
                    Id_Carro = table.Column<string>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    CarroId_Placa = table.Column<string>(nullable: true),
                    CarroId_Dono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.Id_Carro, x.Id_Ticket });
                    table.ForeignKey(
                        name: "FK_Tickets_Carros_CarroId_Placa_CarroId_Dono",
                        columns: x => new { x.CarroId_Placa, x.CarroId_Dono },
                        principalTable: "Carros",
                        principalColumns: new[] { "Id_Placa", "Id_Dono" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_ClienteId_Cpf_ClienteNome",
                table: "Carros",
                columns: new[] { "ClienteId_Cpf", "ClienteNome" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CarroId_Placa_CarroId_Dono",
                table: "Tickets",
                columns: new[] { "CarroId_Placa", "CarroId_Dono" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteId_Cpf_ClienteNome",
                table: "Carros",
                columns: new[] { "ClienteId_Cpf", "ClienteNome" },
                principalTable: "Clientes",
                principalColumns: new[] { "Id_Cpf", "Nome" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteId_Cpf_ClienteNome",
                table: "Carros");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Carros_ClienteId_Cpf_ClienteNome",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ClienteId_Cpf",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "ClienteNome",
                table: "Carros");
        }
    }
}
