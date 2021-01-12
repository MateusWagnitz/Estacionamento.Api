using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingContext.Models
{
    class RemoverModel
    {
        public DateTime HoraSaida { get; set; }
        public bool Excluido { get; set; }
        public double ValorFinal { get; set; }
        public DateTime HoraEntrada { get; set; }
    }
}
