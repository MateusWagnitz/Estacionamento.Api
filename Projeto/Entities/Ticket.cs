using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Entities
{
    public class Ticket
    {
        
        public int TicketId { get;  set; }
        public string CarroId { get;  set; }
        public bool Excluido { get; set; }
        public double ValorFinal { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public bool Mensalista { get; set; }


    }
}
