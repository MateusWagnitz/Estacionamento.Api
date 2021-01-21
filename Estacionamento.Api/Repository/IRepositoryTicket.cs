using ParkingContext.Models;
using Projeto.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public interface IRepositoryTicket
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int ticketId);
        Task<bool> Adiciona(Ticket model);
        Task<bool> Atualiza(string placa, AdicionaTicket model);
        Task<bool> Remove(int ticketId);
    }
}
