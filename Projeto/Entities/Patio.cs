using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParkingModel
{
    public class Patio
    {
        
        public int Patio_Id { get; set; }
        public string Cpf { get; set; }
        public string Placa { get; set; }
        public int Vaga { get; set; }
        public bool Excluido { get; set; }
        public double ValorFinal { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public bool Mensalista { get; set; }

    }



}
