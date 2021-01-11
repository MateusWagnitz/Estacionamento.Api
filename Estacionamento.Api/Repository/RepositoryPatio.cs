using Estacionamento.Api.Data;
using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Repository
{
    public class RepositoryPatio : IRepositoryPatio
    {

        public readonly EstacionamentoContext _context;

        public RepositoryPatio(EstacionamentoContext context)
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
            var query = await _context.Carros                              
                .OrderByDescending(car => car.HoraEntrada)
                .ToListAsync();

            if (query == null)
            {
                throw new System.InvalidOperationException("Não existem carros no estacionamento neste momento.");
            }

            return query;
        }

        public async Task<Carro> GetCarById(string placa)
        {
            var query = await _context.Carros
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                throw new System.InvalidOperationException("O Veículo não foi encontrado!");
            }

            return query;
        }


        public async Task<bool> AdicionaCarro(Carro model)
        {            
            var car = new Carro
            {
                Placa = model.Placa,
                Id_Dono = model.Id_Dono,               
                Marca = model.Marca,
                Modelo = model.Modelo
                //HoraEntrada = DateTime.Now, 
            };

            _context.Add(car);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AtualizaCarro(string placa, Carro model)
        {

            var carro = await _context.Carros
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (carro == null)
            {
                throw new System.InvalidOperationException("O Veículo não foi encontrado!");
            }
         

            await _context.SaveChangesAsync();

            return true;
        }

        //public async Task<bool> Remove(string placa)
        //{
        //    var remover = await _context.Tickets
        //        .Where(a => a.Id_Carro == placa)
        //        .FirstOrDefaultAsync();

        //    if (remover == null)
        //    {
        //        throw new System.InvalidOperationException("O Veículo não foi encontrado!");
        //    }

        //    remover.Excluido = true;
        //    remover.HoraSaida = DateTime.Now;

        //    remover.Valor = Calcula(remover.HoraEntrada, remover.HoraSaida);

        //    await _context.SaveChangesAsync();

        //    return true;
        //}

        //public double Calcula(DateTime entrada, DateTime saida)
        //{

        //    var horaEntrada = entrada.Hour * 60 + entrada.Minute;
        //    var horaSaida = saida.Hour * 60 + saida.Minute;

        //    var valorFinal = Convert.ToDouble(((horaSaida - horaEntrada) / 30) * 5);



        //    return valorFinal;
        //}

        // Not Implemented
        Task<List<Patio>> IRepositoryPatio.GetAllCars()
        {
            throw new NotImplementedException();
        }

        Task<Patio> IRepositoryPatio.GetCarById(string placa)
        {
            throw new NotImplementedException();
        }

    }
}
