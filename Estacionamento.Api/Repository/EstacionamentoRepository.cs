using Estacionamento.Api.Data;

using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public class EstacionamentoRepository : IEstacionamentoRepository
    {
        private readonly EstacionamentoContext _context;

        public EstacionamentoRepository(EstacionamentoContext context)
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

        public async Task<Carro[]> GetAllCarros(bool incluirPatio = false)
        {
            IQueryable<Carro> query = _context.Carros
                .Include(h => h.Id_Dono)
                .Include(h => h.Id_Placa);

            if (incluirPatio)
            {
                query = query.Include(h => h.Tickets)
                         .ThenInclude(carrob => carrob.Carro);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id_Dono);

            return await query.ToArrayAsync();
        }

        public async Task<Carro> GetCarroById(string id, bool incluirPatio = false)
        {
            IQueryable<Carro> query = _context.Carros
                .Include(h => h.Id_Dono)
                .Include(h => h.Id_Placa);

            if (incluirPatio)
            {
                query = query.Include(h => h.Marca);                        
            }

            query = query.AsNoTracking().OrderBy(h => h.Id_Dono);

            return await query.FirstOrDefaultAsync(h => h.Id_Dono == id);
        }

        public async Task<Cliente[]> GetClienteByNome(string nome, bool incluirPatio = false)
        {
            IQueryable<Cliente> query = _context.Clientes
                .Include(h => h.Nome)
                .Include(h => h.Id_Cpf);

            if (incluirPatio)
            {
                query = query.Include(h => h.StatusCliente);
                         
            }

            query = query.AsNoTracking()
                        .Where(h => h.Nome.Contains(nome))
                        .OrderBy(h => h.Id_Cpf);

            return await query.ToArrayAsync();
        }

        public async Task<Ticket[]> GetAllTickets(bool incluirPatio = false)
        {
            IQueryable<Ticket> query = _context.Tickets;

            if (incluirPatio)
            {
                query = query.Include(h => h.Id_Ticket);
                         
            }

            query = query.AsNoTracking().OrderBy(h => h.Id_Ticket);

            return await query.ToArrayAsync();
        }

        public async Task<Ticket> GetTicketById(int id, bool incluirPatio = false)
        {
            IQueryable<Ticket> query = _context.Tickets;

            if (incluirPatio)
            {
                query = query.Include(h => h.Id_Ticket);
                         
            }

            query = query.AsNoTracking().OrderBy(h => h.Id_Ticket);

            return await query.FirstOrDefaultAsync();
        }

        Task<Carro> IEstacionamentoRepository.GetCarroById(int id, bool incluirPatio)
        {
            throw new NotImplementedException();
        }
    }
}

