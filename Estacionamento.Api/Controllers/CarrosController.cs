using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingContext;
using ParkingModel;

namespace ParkingWebApi.Controller
{
    [Route("site/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {


        private readonly IRepositoryPatio repo;

        public CarrosController(IRepositoryPatio repo)
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

        [HttpPost]
        public async Task<bool> Insere([FromBody] Carro model)
        {
            return await this.repo.AddCar(model);
        }

    }
}
