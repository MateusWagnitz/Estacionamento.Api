﻿// <auto-generated />
using System;
using Estacionamento.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estacionamento.Api.Migrations
{
    [DbContext(typeof(EstacionamentoContext))]
    [Migration("20210111110306_segunda")]
    partial class segunda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Projeto.Entities.Carro", b =>
                {
                    b.Property<string>("Placa");

                    b.Property<string>("Id_Dono");

                    b.Property<string>("ClienteCpf");

                    b.Property<string>("ClienteNome");

                    b.Property<DateTime>("HoraEntrada");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.HasKey("Placa", "Id_Dono");

                    b.HasIndex("ClienteCpf", "ClienteNome");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Projeto.Entities.Cliente", b =>
                {
                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<int>("StatusCliente");

                    b.HasKey("Cpf", "Nome");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projeto.Entities.Ticket", b =>
                {
                    b.Property<string>("Id_Carro");

                    b.Property<string>("Id_Ticket");

                    b.Property<string>("CarroId_Dono");

                    b.Property<string>("CarroPlaca");

                    b.Property<bool>("Excluido");

                    b.Property<DateTime>("HoraEntrada");

                    b.Property<DateTime>("HoraSaida");

                    b.Property<double>("Valor");

                    b.HasKey("Id_Carro", "Id_Ticket");

                    b.HasIndex("CarroPlaca", "CarroId_Dono");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Projeto.Entities.Carro", b =>
                {
                    b.HasOne("Projeto.Entities.Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteCpf", "ClienteNome");
                });

            modelBuilder.Entity("Projeto.Entities.Ticket", b =>
                {
                    b.HasOne("Projeto.Entities.Carro", "Carro")
                        .WithMany("Tickets")
                        .HasForeignKey("CarroPlaca", "CarroId_Dono");
                });
#pragma warning restore 612, 618
        }
    }
}
