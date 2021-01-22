using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingContext;
using ParkingModel;

namespace ParkingWebApi.Controller
{
    [Route("site/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {


        private readonly IRepositoryCarro repo;

        public CarroController(IRepositoryCarro repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Carro>> Get()
        {
            return await this.repo.GetAllCars();
        }

        [HttpGet("{placa}")]
        public async Task<Carro> GetById(string placa)
        {
            return await this.repo.GetCarById(placa);
        }

        [HttpPost]
        public async Task<bool> Insert([FromBody]Carro model)
        {
            return await this.repo.AddCar(model);
        }

    }
}
