using Estacionamento.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estacionamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly EstacionamentoContext _context;

        public ClienteController(EstacionamentoContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>        
        [HttpGet("filtro/{cliente}")]
        public ActionResult GetFiltro(string cliente)
        {
            var listClientes = _context.Clientes
                            .Where(h => EF.Functions.Like(h.Id_Cpf, $"%{cliente}%"))
                            .OrderBy(h => h.Nome)
                            .LastOrDefault();

            return Ok(listClientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Cliente { Nome = "João da silva" },
                new Cliente { Nome = "João magalhães" },
                new Cliente { Nome = "João zezinho" },
                new Cliente { Nome = "João elefante" },
                new Cliente { Nome = "João palito" }
            );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
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
