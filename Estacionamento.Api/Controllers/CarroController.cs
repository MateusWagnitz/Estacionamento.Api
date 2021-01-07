using Estacionamento.Api.Data;
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
    public class CarroController : ControllerBase
    {
        public readonly EstacionamentoContext _context;

        public CarroController(EstacionamentoContext context)
        {
            _context = context;
        }

        // GET api/carros
        [HttpGet("filtro/{carro}")]
        public ActionResult GetFiltro(string carro)
        {
            var listCarro = _context.Carros
                            .Where(h => EF.Functions.Like(h.Marca, $"%{carro}%"))
                            .OrderBy(h => h.Marca)
                            .LastOrDefault();

            return Ok(listCarro);
        }


        // GET api/carros/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Carro { Marca = "Fiat", Modelo = "Marea", Id_Dono = "1" },
                new Carro { Marca = "Fiat", Modelo = "Bravo", Id_Dono = "2" },
                new Carro { Marca = "Fiat", Modelo = "Doblo", Id_Dono = "3" },
                new Carro { Marca = "Fiat", Modelo = "Toro", Id_Dono = "4" },
                new Carro { Marca = "Fiat", Modelo = "Palio", Id_Dono = "5" }
                            
            );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/carros
        [HttpPost]
        public void Post([FromBody] string carros)
        {
        }

        // PUT api/carros/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string carros)
        {
        }

        // DELETE api/carros/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            var carro = _context.Carros
                                .Where(x => x.Id_Placa == id.ToString())
                                .Single();
            _context.Carros.Remove(carro);
            _context.SaveChanges();
        }
    }
}
