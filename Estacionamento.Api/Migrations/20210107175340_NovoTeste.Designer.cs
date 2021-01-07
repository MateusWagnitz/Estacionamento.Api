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
    [Migration("20210107175340_NovoTeste")]
    partial class NovoTeste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Projeto.Entities.Carro", b =>
                {
                    b.Property<string>("Id_Placa");

                    b.Property<string>("Id_Dono");

                    b.Property<string>("ClienteId_Cpf");

                    b.Property<string>("ClienteNome");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.HasKey("Id_Placa", "Id_Dono");

                    b.HasIndex("ClienteId_Cpf", "ClienteNome");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Projeto.Entities.Cliente", b =>
                {
                    b.Property<string>("Id_Cpf");

                    b.Property<string>("Nome");

                    b.Property<int>("StatusCliente");

                    b.HasKey("Id_Cpf", "Nome");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projeto.Entities.Ticket", b =>
                {
                    b.Property<string>("Id_Carro");

                    b.Property<string>("Id_Ticket");

                    b.Property<string>("CarroId_Dono");

                    b.Property<string>("CarroId_Placa");

                    b.Property<DateTime>("DataEntrada");

                    b.Property<DateTime?>("DataSaida");

                    b.Property<double>("Valor");

                    b.HasKey("Id_Carro", "Id_Ticket");

                    b.HasIndex("CarroId_Placa", "CarroId_Dono");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Projeto.Entities.Carro", b =>
                {
                    b.HasOne("Projeto.Entities.Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteId_Cpf", "ClienteNome");
                });

            modelBuilder.Entity("Projeto.Entities.Ticket", b =>
                {
                    b.HasOne("Projeto.Entities.Carro", "Carro")
                        .WithMany("Tickets")
                        .HasForeignKey("CarroId_Placa", "CarroId_Dono");
                });
#pragma warning restore 612, 618
        }
    }
}
