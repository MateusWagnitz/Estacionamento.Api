using System;
using System.Collections.Generic;


namespace Projeto.Entities
{
    public class Ticket
    {
        public string Id_Ticket { get;  set; }
        public string Id_Carro { get;  set; }
        public bool Excluido { get; set; }
        public double ValorFinal { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public bool Mensalista { get; set; }


    }
}
