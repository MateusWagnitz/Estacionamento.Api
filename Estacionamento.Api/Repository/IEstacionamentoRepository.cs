using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public interface IEstacionamentoRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Carro[]> GetAllCarros(bool incluirPatio = false);
        Task<Carro> GetCarroById(int id, bool incluirPatio = false);
        Task<Cliente[]> GetClienteByNome(string nome, bool incluirPatio = false);

        Task<Ticket[]> GetAllTickets(bool incluirPatio = false);
        Task<Ticket> GetTicketById(int id, bool incluirPatio = false);
    }
}
