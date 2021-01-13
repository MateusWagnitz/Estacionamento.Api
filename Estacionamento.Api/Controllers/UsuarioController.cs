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
    public class UsuarioController : ControllerBase
    {


        private readonly IRepositoryUsuario repo;

        public UsuarioController(IRepositoryUsuario repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public async Task<List<Usuario>> Busca()
        {
            return await this.repo.BuscaGeral();
        }

        [HttpGet("{cpf}")]
        public async Task<UsuarioBusca> BuscaId(string cpf)
        {
            return await this.repo.Busca(cpf);
        }

        [HttpPost("")]
        public async Task<bool> Insere(Usuario model)
        {
            return await this.repo.Adiciona(model);
        }

        [HttpPut("{cpf}")]
        public async Task<bool> AtualizaDados(string cpf, Usuario model)
        {
            return await this.repo.Atualiza(cpf, model);
        }
    }
}
