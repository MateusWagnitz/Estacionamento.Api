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
                .OrderBy(car => car.TicketId)
                .ToListAsync();

            if (query == null)
            {
                throw new InvalidOperationException("Não existem Tickets no estacionamento.");
            }

            return query;
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            var query = await _context.Ticket
                .Where(a => a.TicketId == ticketId)
                .FirstOrDefaultAsync();

            if (query == null)
                throw new InvalidOperationException("O Ticket não foi encontrado!");


            return query;
        }

        public async Task<bool> Adiciona(Ticket model)
        {
            var ticket = new Ticket
            {              
                CarroId = model.CarroId,
                HoraEntrada = model.HoraEntrada,
                HoraSaida = model.HoraSaida,
                ValorFinal = model.ValorFinal,
                Mensalista = model.Mensalista
            };

            _context.Add(ticket);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string placa, AdicionaTicket model)
        {

            var carro = await _context.Ticket
                .Where(a => a.CarroId == placa)
                .FirstOrDefaultAsync();

            if (carro == null)
            {
                throw new InvalidOperationException("O Veículo não foi encontrado!");
            }

            carro.Mensalista = model.Mensalista;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remove(int ticketId)
        {
            var remover = await _context.Ticket
                .Where(a => a.TicketId == ticketId)
                .FirstOrDefaultAsync();

            remover.Excluido = true;

            await _context.SaveChangesAsync();
            //if (remover == null)
            //{
            //    throw new InvalidOperationException("O Veículo não foi encontrado!");
            //}

            //remover.Excluido = true;
            //remover.HoraSaida = DateTime.Now;

            //remover.ValorFinal = Calcula(remover.HoraEntrada, remover.HoraSaida);

            //await _context.SaveChangesAsync();

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

