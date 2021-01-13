using ParkingContext.Models;
using ParkingModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingContext
{
    public interface IRepositoryUsuario
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Usuario>> BuscaGeral();
        Task<UsuarioBusca> Busca(string cpf);
        Task<bool> Adiciona(Usuario model);
        Task<bool> Atualiza(string cpf, Usuario model);
    }
}
