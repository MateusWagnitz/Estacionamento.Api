using Estacionamento.Api.Data;

using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public class RepositoryTicket : IRepositoryTicket
    {
        public readonly EstacionamentoContext _context;

        public RepositoryTicket(EstacionamentoContext context)
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


        public async Task<Ticket> AddTicket(Ticket model)
        {
            //public Ticket(string id_Ticket, string id_Carro, bool excluido, DateTime horaEntrada, DateTime horaSaida, double valor)
            var tic = new Ticket
            {
                Id_Ticket = model.Id_Ticket,
                Id_Carro = model.Id_Carro,
                HoraEntrada = DateTime.Now,
            };

            _context.Add(tic);

            await _context.SaveChangesAsync();

            return tic;
        }

        public async Task<List<Ticket>> GetAllTickets(Ticket model)
        {
            var query = await _context.Tickets
                .OrderByDescending(car => car.HoraEntrada)
                .ToListAsync();

            if (query == null)
            {
                throw new System.InvalidOperationException("Não existem tickets no estacionamento neste momento.");
            }

            return query.ToList();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var query = await _context.Tickets
                .Where(a => a.Excluido != true)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                throw new System.InvalidOperationException("O Ticket não foi encontrado!");
            }

            return query;
        }


        public async Task<bool> EndTicket(string placa)
        {
            var remover = await _context.Tickets
                .Where(a => a.Id_Carro == placa)
                .FirstOrDefaultAsync();

            if (remover == null)
            {
                throw new System.InvalidOperationException("O Ticket não foi encontrado!");
            }

            remover.Excluido = true;
            remover.HoraSaida = DateTime.Now;

            remover.Valor = Calcula(remover.HoraEntrada, remover.HoraSaida);

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

        Task<Ticket> IRepositoryTicket.EndTicket(string placa)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetAllTickets()
        {
            throw new NotImplementedException();
        }
    }
}

