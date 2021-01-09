using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public interface IRepositoryCliente
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Cliente>> BuscaGeral();
        Task<Cliente> Busca(string carros);
        Task<bool> Adiciona(Cliente model);
        Task<bool> Atualiza(string cpf, Cliente model);
    }
}
