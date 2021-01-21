﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingContext;

namespace Estacionamento.Api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkingModel.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Placa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CarroId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("ParkingModel.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NomeCompleto")
                        .HasColumnName("NomeCompleto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ParkingModel.Patio", b =>
                {
                    b.Property<int>("PatioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Placa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PatioId");

                    b.ToTable("Patio");
                });

            modelBuilder.Entity("Projeto.Entities.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TicketId")
                        .HasColumnType("int");

                    b.Property<string>("CarroId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Excluido")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("HoraEntrada")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HoraSaida")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Mensalista")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("ValorFinal")
                        .HasColumnType("double");

                    b.HasKey("TicketId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ParkingModel.Carro", b =>
                {
                    b.HasOne("ParkingModel.Cliente", null)
                        .WithMany("Carros")
                        .HasForeignKey("ClienteId");
                });
#pragma warning restore 612, 618
        }
    }
}
