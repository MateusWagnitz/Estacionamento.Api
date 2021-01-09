using Estacionamento.Api.Data;
using Estacionamento.Api.Repository;
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
        private readonly IRepositoryCliente repo;
        //public readonly EstacionamentoContext _context;

        public ClienteController(IRepositoryCliente repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<List<Cliente>> Get()
        {
            return await this.repo.BuscaGeral();
        }

        [HttpGet("{cpf}")]
        public async Task<Cliente> BuscaId(string cpf)
        {
            return await this.repo.Busca(cpf);
        }

        [HttpPost("")]
        public async Task<bool> Insere(Cliente model)
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
