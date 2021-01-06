using Projeto.Entities.Enums;
using System.Collections.Generic;


namespace Projeto.Entities
{
    class Cliente
    {
        public string Id_Cpf { get; private set; }
        public string Nome { get; set; }
        public StatusCliente StatusCliente { get; set; }


        public List<Cliente> ListaCliente = new List<Cliente>();

        public Cliente() { }

        public Cliente(string nome, string cpf, StatusCliente statusCliente)
        {
            Nome = nome;
            Id_Cpf = cpf;
            StatusCliente = statusCliente;
        }

    }

}

