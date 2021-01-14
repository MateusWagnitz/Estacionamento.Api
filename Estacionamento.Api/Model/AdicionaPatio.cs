using ParkingModel;
using System;
using System.Collections.Generic;
using System.Text;
using static ParkingModel.Patio;

namespace ParkingContext.Models
{
    public class AdicionaTicket
    {
        public string Cpf { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public bool Mensalista { get; set; }

    }
}
