using Microsoft.EntityFrameworkCore;
using ParkingContext;
using ParkingContext.Models;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public class RepositoryTicket : IRepositoryTicket
    {
        public readonly Context _context;

        public RepositoryTicket(Context context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        public async Task<List<Ticket>> GetAllTickets()
        {
            var query = await _context.Ticket
                .Where(a => a.Excluido != true)
                .OrderByDescending(car => car.HoraEntrada)
                .ToListAsync();

            if (query == null)
            {
                throw new InvalidOperationException("Não existem Tickets no estacionamento.");
            }

            return query;
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var query = await _context.Ticket
                .Where(a => a.Excluido != true)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                throw new InvalidOperationException("O Ticket não foi encontrado!");
            }

            return query;
        }

        public async Task<bool> Adiciona(AdicionaTicket model)
        {
            var ticket = new Ticket
            {

                Id_Carro = model.Placa,
                HoraEntrada = DateTime.Now,
                Mensalista = model.Mensalista
            };

            _context.Add(ticket);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string placa, AdicionaTicket model)
        {

            var carro = await _context.Ticket
                .Where(a => a.Id_Carro == placa)
                .FirstOrDefaultAsync();

            if (carro == null)
            {
                throw new InvalidOperationException("O Veículo não foi encontrado!");
            }

            carro.Mensalista = model.Mensalista;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remove(string placa)
        {
            var remover = await _context.Ticket
                .Where(a => a.Id_Carro == placa)
                .FirstOrDefaultAsync();

            if (remover == null)
            {
                throw new InvalidOperationException("O Veículo não foi encontrado!");
            }

            remover.Excluido = true;
            remover.HoraSaida = DateTime.Now;

            remover.ValorFinal = Calcula(remover.HoraEntrada, remover.HoraSaida);

            await _context.SaveChangesAsync();

            return true;
        }

        public double Calcula(DateTime entrada, DateTime saida)
        {

            var horaEntrada = entrada.Hour * 60 + entrada.Minute;
            var horaSaida = saida.Hour * 60 + saida.Minute;

            var valorFinal = Convert.ToDouble(((horaSaida - horaEntrada) / 30) * 5);



            return valorFinal;
        }

        
      
    }
}

