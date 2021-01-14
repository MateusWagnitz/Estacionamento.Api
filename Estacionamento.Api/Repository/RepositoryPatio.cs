using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingContext.Models;
using ParkingModel;
using Projeto.Entities;

namespace ParkingContext
{
    public class RepositoryPatio : IRepositoryPatio
    {
        private readonly Context _context;

        public RepositoryPatio(Context context)
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

        public async Task<List<Patio>> GetAllCars()
        {
            var query = await _context.Patio
                .Where(a => a.Excluido != true)
                .ToListAsync();

            if (query == null)
            {
                throw new InvalidOperationException("Não existem veículos no estacionamento.");
            }

            return query;
        }

        public async Task<Patio> GetCarById(string placa)
        {
            var query = await _context.Patio
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                throw new InvalidOperationException("O Veículo não foi encontrado!");
            }

            return query;
        }


    }
}