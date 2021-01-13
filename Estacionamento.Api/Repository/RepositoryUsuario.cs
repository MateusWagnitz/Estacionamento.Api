using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingContext.Models;
using ParkingModel;

namespace ParkingContext
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        private readonly Context _context;

        public RepositoryUsuario(Context context)
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

        public async Task<List<Usuario>> BuscaGeral()
        {
            var query = await _context.Usuario
                .Include(e => e.Carros)
                .ToListAsync();

            return query;
        }

        public async Task<UsuarioBusca> Busca(string cpf)
        {
            var query = await _context.Usuario
                .Where(a => a.Cpf == cpf)
                .Select(a => new {
                    a.NomeCompleto,
                    a.Idade,
                    a.Telefone
                })
                .FirstOrDefaultAsync();


            if (query == null)
            {
                throw new InvalidOperationException("O usuário não foi encontrado!");
            }

            var usuario = new UsuarioBusca
            {
                NomeCompleto = query.NomeCompleto,
                Idade = query.Idade,
                Telefone = query.Telefone
            };

            return usuario;
        }


        public async Task<bool> Adiciona(Usuario model)
        {

            var busca = await _context.Usuario
                .Where(a => a.Cpf == model.Cpf)
                .FirstOrDefaultAsync();

            if (busca != null)
            {
                throw new InvalidOperationException("Esse usuário já possui cadastro!");
            }

            var usuario = new Usuario
            {
                Cpf = model.Cpf,
                NomeCompleto = model.NomeCompleto,
                DataNascimento = model.DataNascimento,
                Email = model.Email,
                Telefone = model.Telefone,
                Carros = model.Carros
            };

            _context.Add(usuario);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string cpf, Usuario model)
        {

            var usuario = await _context.Usuario
                .Where(a => a.Cpf == cpf)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                throw new InvalidOperationException("O usuário não foi encontrado!");
            }

            usuario.NomeCompleto = model.NomeCompleto;
            usuario.DataNascimento = model.DataNascimento;
            usuario.Email = model.Email;
            usuario.Carros = model.Carros;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}