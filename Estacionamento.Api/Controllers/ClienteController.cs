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
    public class ClienteController : ControllerBase
    {


        private readonly IRepositoryCliente repo;

        public ClienteController(IRepositoryCliente repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public async Task<List<Cliente>> Busca()
        {
            return await this.repo.BuscaGeral();
        }

        [HttpGet("{cpf}")]
        public async Task<ClienteBusca> BuscaId(string cpf)
        {
            return await this.repo.Busca(cpf);
        }

        [HttpPost]
        public async Task<bool> Insere([FromBody]Cliente model)
        {
            return await this.repo.Adiciona(model);
        }

        [HttpPut("{cpf}")]
        public async Task<bool> AtualizaDados(string cpf, Cliente model)
        {
            return await this.repo.Atualiza(cpf, model);
        }
    }
}
