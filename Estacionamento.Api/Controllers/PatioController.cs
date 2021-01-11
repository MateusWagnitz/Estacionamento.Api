using Estacionamento.Api.Data;
using Estacionamento.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        public readonly IRepositoryPatio repo;

        public PatioController(IRepositoryPatio repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Patio>> Get()
        {
            return await repo.GetAllCars();
        }

        [HttpGet("{placa}")]
        public async Task<Patio> BuscaId(string placa)
        {
            return await repo.GetCarById(placa);
        }

        [HttpPost]
        public async Task<ActionResult> Insere([FromBody]Carro car)
        {
            await this.repo.AdicionaCarro(car);
                return Ok();
        }

        [HttpPut("{placa}")]
        public async Task<bool> AtualizaDados(string placa, Carro car)
        {
            return await this.repo.AtualizaCarro(placa, car);
        }

        //[HttpDelete("{placa}")]
        //public async Task<bool> Remove(string placa)
        //{
        //    return await this.repo.Remove(placa);
        //}

    }
}
