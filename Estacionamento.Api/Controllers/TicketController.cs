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
    public class TicketController : ControllerBase
    {
        public readonly EstacionamentoContext _context;

        public TicketController(EstacionamentoContext context)
        {
            _context = context;
        }

        // GET: api/<TicketController>
        [HttpGet("filtro/{ticket}")]
        public ActionResult GetFiltro(string ticket)
        {
            var listTickets = _context.Tickets
                            .Where(h => EF.Functions.Like(h.Id_Ticket, $"%{ticket}%"))
                            .OrderBy(h => h.Id_Ticket)
                            .LastOrDefault();

            return Ok(listTickets);
        }

        // GET api/<TicketController>/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                //new Ticket {   },
                //new Ticket {   },
                //new Ticket {   },
                //new Ticket {   },
                //new Ticket {   }
                
            );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/<TicketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            var ticket = _context.Tickets
                                .Where(x => x.Id_Ticket == id.ToString())
                                .Single();
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }
    }
}
