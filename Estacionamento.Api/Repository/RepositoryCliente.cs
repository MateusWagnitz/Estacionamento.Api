using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingContext.Models;
using ParkingModel;

namespace ParkingContext
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private readonly Context _context;

        public RepositoryCliente(Context context)
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
            var query = await _context.Cliente
                .Include(e => e.Carros)
                .ToListAsync();

            return query;
        }

        public async Task<ClienteBusca> Busca(string cpf)
        {
            var query = await _context.Cliente
                .Where(a => a.Cpf == cpf)
                .Select(a => new {
                    a.NomeCompleto
                })
                .FirstOrDefaultAsync();


            if (query == null)
            {
                throw new InvalidOperationException("O usuário não foi encontrado!");
            }

            var usuario = new ClienteBusca
            {
                NomeCompleto = query.NomeCompleto
            };

            return usuario;
        }


        public async Task<bool> Adiciona(Cliente model)
        {

            var busca = await _context.Cliente
                .Where(a => a.Cpf == model.Cpf)
                .FirstOrDefaultAsync();

            if (busca != null)
            {
                throw new InvalidOperationException("Esse usuário já possui cadastro!");
            }

            var usuario = new Cliente
            {
                Cpf = model.Cpf,
                NomeCompleto = model.NomeCompleto,
                Carros = model.Carros
            };

            _context.Add(usuario);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string cpf, Cliente model)
        {

            var usuario = await _context.Cliente
                .Where(a => a.Cpf == cpf)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                throw new InvalidOperationException("O usuário não foi encontrado!");
            }

            usuario.NomeCompleto = model.NomeCompleto;
            usuario.Carros = model.Carros;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}