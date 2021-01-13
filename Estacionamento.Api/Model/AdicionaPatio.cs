using ParkingModel;
using System;
using System.Collections.Generic;
using System.Text;
using static ParkingModel.Patio;

namespace ParkingContext.Models
{
    public class AdicionaPatio
    {
        public string Cpf { get; set; }
        public string Placa { get; set; }
        public int Vaga { get; set; }
        public bool Mensalista { get; set; }

    }
}
