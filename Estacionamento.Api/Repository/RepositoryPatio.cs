using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingContext.Models;
using ParkingModel;

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
                .OrderByDescending(car => car.HoraEntrada)
                .ToListAsync();

            if (query == null)
            {
                throw new System.InvalidOperationException("Não existem veículos no estacionamento.");
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
                throw new System.InvalidOperationException("O Veículo não foi encontrado!");
            }

            return query;
        }


        public async Task<bool> Adiciona(AdicionaPatio model)
        {
            var patio = new Patio
            {
                Cpf = model.Cpf,
                Placa = model.Placa,
                HoraEntrada = DateTime.Now,
                Vaga = model.Vaga,
                Mensalista = model.Mensalista
            };

            _context.Add(patio);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Atualiza(string placa, AdicionaPatio model)
        {

            var carro = await _context.Patio
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (carro == null)
            {
                throw new System.InvalidOperationException("O Veículo não foi encontrado!");
            }


            carro.Vaga = model.Vaga;
            carro.Mensalista = model.Mensalista;
            //carro.Info.AddRange(model.Informacoes);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Remove(string placa)
        {
            var remover = await _context.Patio
                .Where(a => a.Placa == placa)
                .FirstOrDefaultAsync();

            if (remover == null)
            {
                throw new System.InvalidOperationException("O Veículo não foi encontrado!");
            }

            remover.Excluido = true;
            remover.HoraSaida = DateTime.Now;

            remover.ValorFinal = Calcula(remover.HoraEntrada, remover.HoraSaida);

            await _context.SaveChangesAsync();

            return true;
        }

        public double Calcula(DateTime entrada, DateTime saida)
        {

            var horaEntrada = entrada.Hour * 60 + entrada.Minute;
            var horaSaida = saida.Hour * 60 + saida.Minute;

            var valorFinal = Convert.ToDouble(((horaSaida - horaEntrada) / 30) * 5);



            return valorFinal;
        }

    }
}