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
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
        public bool Mensalista { get; set; }

    }
}
