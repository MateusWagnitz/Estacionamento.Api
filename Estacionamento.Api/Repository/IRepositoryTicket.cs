using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public interface IRepositoryTicket
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Ticket> AddTicket(Ticket model);
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> EndTicket(string placa);
    }
}
