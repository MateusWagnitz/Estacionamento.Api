using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingModel;

namespace ParkingContext
{
    public class RepositoryCarro : IRepositoryCarro
    {
        private readonly Context _context;

        public RepositoryCarro(Context context)
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

        public async Task<List<Carro>> GetAllCars()
        {
            var query = await _context.Carro
                .ToListAsync();

            if (query == null)
            {
                throw new InvalidOperationException("Não existem veículos no estacionamento.");
            }

            return query;
        }

        public async Task<Carro> GetCarById(string placa)
        {
            var query = await _context.Carro
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                throw new InvalidOperationException("O Veículo não foi encontrado!");
            }

            return query;
        }

        public async Task<bool> AddCar(Carro model)
        {

            var query = await _context.Carro
                .Where(a => a.Placa == model.Placa)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                throw new InvalidOperationException("Esse carro já possui cadastro!");
            }

            var carro = new Carro
            {
                Placa = model.Placa,
                Marca = model.Marca,
                Modelo = model.Modelo
            };

            _context.Add(carro);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}