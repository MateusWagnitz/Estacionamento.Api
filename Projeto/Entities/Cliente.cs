using System;
using System.Collections.Generic;

namespace ParkingModel
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }

        public List<Carro> Carros { get; set; }
    }
}
