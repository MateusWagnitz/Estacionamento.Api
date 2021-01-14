using ParkingContext.Models;
using ParkingModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingContext
{
    public interface IRepositoryCliente
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Cliente>> BuscaGeral();
        Task<ClienteBusca> Busca(string cpf);
        Task<bool> Adiciona(Cliente model);
        Task<bool> Atualiza(string cpf, Cliente model);
    }
}
