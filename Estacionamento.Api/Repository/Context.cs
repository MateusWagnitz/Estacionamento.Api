using Microsoft.EntityFrameworkCore;
using ParkingModel;
using Projeto.Entities;

namespace ParkingContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Carro> Carro { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Patio> Patio { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // -------------------------- Alterações Usuário

            modelBuilder.Entity<Cliente>()
                .Property(s => s.Cpf)
                .HasColumnName("Cpf_Id")
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasKey(a => a.ClienteId);

            modelBuilder.Entity<Cliente>()
                .Property(s => s.NomeCompleto)
                .HasColumnName("NomeCompleto");

            // -------------------------- Alterações Ticket

            modelBuilder.Entity<Ticket>()
                .HasKey(a => a.TicketId);

            modelBuilder.Entity<Ticket>()
                .Property(s => s.TicketId)
                .HasColumnName("Id_Ticket");



            // -------------------------- Alterações Pátio

            modelBuilder.Entity<Patio>()
                .HasKey(a => a.Patio_Id);
                
            modelBuilder.Entity<Patio>()
                .Property(s => s.Cpf)
                .HasColumnName("Cpf_Id")
                .IsRequired();

            // -------------------------- Alterações Carro

            modelBuilder.Entity<Carro>()
                .HasKey(a => a.CarroId);

            modelBuilder.Entity<Carro>()
                .Property(a => a.CarroId)
                .HasColumnName("Carro_Id");

            modelBuilder.Entity<Carro>()
                .HasOne(a => a.Cliente)
                .WithMany(a => a.Carros);
        }
    }
}
