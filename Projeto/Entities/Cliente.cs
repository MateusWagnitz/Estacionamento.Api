using Projeto.Entities.Enums;
using System.Collections.Generic;


namespace Projeto.Entities
{
    public class Cliente
    {
        public string Cpf { get;  set; }
        public string Nome { get; set; }
        public StatusCliente StatusCliente { get; set; }

        public List<Carro> Carros { get; set; }


        //public List<Cliente> ListaCliente = new List<Cliente>();

        //public Cliente() { }

        //public Cliente(string nome, string cpf, StatusCliente statusCliente)
        //{
        //    Nome = nome;
        //    Cpf = cpf;
        //    StatusCliente = statusCliente;
        //}

    }

}

