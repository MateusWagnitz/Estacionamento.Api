using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingContext;
using ParkingContext.Models;
using ParkingModel;

namespace ParkingWebApi.Controller
{
    [Route("site/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {


        private readonly IRepositoryPatio repo;

        public ParkingController(IRepositoryPatio repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Patio>> Get()
        {
            return await this.repo.GetAllCars();
        }

        [HttpGet("{placa}")]
        public async Task<Patio> BuscaId(string placa)
        {
            return await this.repo.GetCarById(placa);
        }

        [HttpPost("")]
        public async Task<bool> Insere(AdicionaPatio car)
        {
            return await this.repo.Adiciona(car);
        }

        [HttpPut("{placa}")]
        public async Task<bool> AtualizaDados(string placa, AdicionaPatio car)
        {
            return await this.repo.Atualiza(placa, car);
        }

        [HttpDelete("{placa}")]
        public async Task<bool> Remove(string placa)
        {
            return await this.repo.Remove(placa);
        }
    }
}
