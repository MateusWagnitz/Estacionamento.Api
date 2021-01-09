using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Api.Migrations
{
    public partial class Refatoramento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteId_Cpf_ClienteNome",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carros_CarroId_Placa_CarroId_Dono",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "DataEntrada",
                table: "Tickets",
                newName: "HoraSaida");

            migrationBuilder.RenameColumn(
                name: "CarroId_Placa",
                table: "Tickets",
                newName: "CarroPlaca");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CarroId_Placa_CarroId_Dono",
                table: "Tickets",
                newName: "IX_Tickets_CarroPlaca_CarroId_Dono");

            migrationBuilder.RenameColumn(
                name: "Id_Cpf",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "ClienteId_Cpf",
                table: "Carros",
                newName: "ClienteCpf");

            migrationBuilder.RenameColumn(
                name: "Id_Placa",
                table: "Carros",
                newName: "Placa");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_ClienteId_Cpf_ClienteNome",
                table: "Carros",
                newName: "IX_Carros_ClienteCpf_ClienteNome");

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Tickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraEntrada",
                table: "Tickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraEntrada",
                table: "Carros",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteCpf_ClienteNome",
                table: "Carros",
                columns: new[] { "ClienteCpf", "ClienteNome" },
                principalTable: "Clientes",
                principalColumns: new[] { "Cpf", "Nome" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Carros_CarroPlaca_CarroId_Dono",
                table: "Tickets",
                columns: new[] { "CarroPlaca", "CarroId_Dono" },
                principalTable: "Carros",
                principalColumns: new[] { "Placa", "Id_Dono" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Clientes_ClienteCpf_ClienteNome",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Carros_CarroPlaca_CarroId_Dono",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "HoraSaida",
                table: "Tickets",
                newName: "DataEntrada");

            migrationBuilder.RenameColumn(
                name: "CarroPlaca",
                table: "Tickets",
                newName: "CarroId_Placa");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CarroPlaca_CarroId_Dono",
                table: "Tickets",
                newName: "IX_Tickets_CarroId_Placa_CarroId_Dono");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "Id_Cpf");

            migrationBuilder.RenameColumn(
                name: "ClienteCpf",
                table: "Carros",
                newName: "ClienteId_Cpf");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Carros",
                newName: "Id_Placa");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_ClienteCpf_ClienteNome",
                table: "Carros",
                newName: "IX_Carros_ClienteId_Cpf_ClienteNome");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Clientes_ClienteId_Cpf_ClienteNome",
                table: "Carros",
                columns: new[] { "ClienteId_Cpf", "ClienteNome" },
                principalTable: "Clientes",
                principalColumns: new[] { "Id_Cpf", "Nome" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Carros_CarroId_Placa_CarroId_Dono",
                table: "Tickets",
                columns: new[] { "CarroId_Placa", "CarroId_Dono" },
                principalTable: "Carros",
                principalColumns: new[] { "Id_Placa", "Id_Dono" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
