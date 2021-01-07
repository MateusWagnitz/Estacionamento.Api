using Projeto.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Data
{
    public class EstacionamentoContext : DbContext
    {
        //public EstacionamentoContext(DbContextOptions<EstacionamentoContext> options) : base(options) { }

        //MySQL
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;userid=developer;password=1234567;database=Estacionamento");
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>(entity =>
            {
                entity.HasKey(e => new { e.Id_Placa, e.Id_Dono });
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new { e.Id_Cpf, e.Nome });
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => new { e.Id_Carro, e.Id_Ticket });
            });
        }      





        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
