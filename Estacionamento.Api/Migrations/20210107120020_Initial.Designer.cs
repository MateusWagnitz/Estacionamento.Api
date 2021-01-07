﻿// <auto-generated />
using Estacionamento.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estacionamento.Api.Migrations
{
    [DbContext(typeof(EstacionamentoContext))]
    [Migration("20210107120020_Initial")]
    partial class Initial
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

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.HasKey("Id_Placa", "Id_Dono");

                    b.ToTable("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}