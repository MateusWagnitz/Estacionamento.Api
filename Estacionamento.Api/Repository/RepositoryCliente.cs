using Estacionamento.Api.Data;
using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public class RepositoryCliente : IRepositoryCliente
    {
        public readonly EstacionamentoContext _context;

        public RepositoryCliente(EstacionamentoContext context)
        {
            _context = context;
        }

        // FUNÇÕES GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        //FUNÇÕES DE MANIPULAÇÃO

        public async Task<List<Cliente>> BuscaGeral()
        {
            var query = await _context.Clientes
                .Include(e => e.Carros)
                .OrderBy(n => n.Nome)
                .ToListAsync();

            return query;
        }

        public async Task<Cliente> Busca(string carros)
        {
            var query = await _context.Carros
                .Where(a => a.Placa == carros)
                .Select(a => new {
                    a.Placa
                })
                .FirstOrDefaultAsync();


            if (query == null)
            {
                throw new System.InvalidOperationException("O cliente não foi encontrado!");
            }
            var cli = new Cliente
            {
                Nome = query.Placa
            };

            return cli;

        }


        public async Task<bool> Adiciona(Cliente model)
        {

            var busca = await _context.Clientes
                .Where(a => a.Cpf == model.Cpf)
                .FirstOrDefaultAsync();

            if (busca != null)
            {
                throw new System.InvalidOperationException("Esse Cliente já possui cadastro!");
            }

            var cli = new Cliente
            {
                Cpf = model.Cpf,
                Nome = model.Nome,
                Carros = model.Carros
            };

            _context.Add(cli);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string cpf, Cliente model)
        {

            var usuario = await _context.Clientes
                .Where(a => a.Cpf == cpf)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                throw new System.InvalidOperationException("O Cliente não foi encontrado!");
            }

            usuario.Nome = model.Nome;
            usuario.Carros = model.Carros;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
