using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public interface IRepositoryPatio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Patio>> GetAllCars();
        Task<Patio> GetCarById(string placa);
        Task<bool> AdicionaCarro(Carro model);
        Task<bool> AdicionaTicket(Ticket model);
        Task<bool> AtualizaCarro(string placa, Carro model);
        Task<bool> AtualizaTicket(string placa, Ticket model);
        Task<bool> Remove(string placa);
    }
}
