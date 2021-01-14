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

        [HttpGet("{placa}")]
        public async Task<Ticket> BuscaId(int id)
        {
            return await this.repo.GetTicketById(id);
        }

        [HttpPost("")]
        public async Task<bool> Insere(AdicionaTicket model)
        {
            return await this.repo.Adiciona(model);
        }

        [HttpPut("{placa}")]
        public async Task<bool> AtualizaDados(string placa, AdicionaTicket car)
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
