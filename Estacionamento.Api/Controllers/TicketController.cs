using Estacionamento.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using ParkingContext.Models;
using Projeto.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Estacionamento.Api.Controllers
{
    [Route("site/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        public readonly IRepositoryTicket repo;

        public TicketController(IRepositoryTicket repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Ticket>> Get()
        {
            return await this.repo.GetAllTickets();
        }

        [HttpGet("{ticketId}")]
        public async Task<Ticket> BuscaId(int ticketId)
        {
            return await this.repo.GetTicketById(ticketId);
        }

        [HttpPost("")]
        public async Task<bool> Insere(Ticket model)
        {
            return await this.repo.Adiciona(model);
        }

        [HttpPut("{ticketId}")]
        public async Task<bool> AtualizaDados(string placa, AdicionaTicket car)
        {
            return await this.repo.Atualiza(placa, car);
        }

        [HttpDelete("{ticketId}")]
        public async Task<bool> Remove(int ticketId)
        {
            return await this.repo.Remove(ticketId);
        }
    }
}
