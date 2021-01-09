using System;
using System.Collections.Generic;


namespace Projeto.Entities
{
    public class Ticket
    {
        public string Id_Ticket { get; private set; }
        public string Id_Carro { get; private set; }
        public bool Excluido { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public double Valor { get; set; }
        public Carro Carro { get; set; }


        //public List<Ticket> ListaTickets = new List<Ticket>();

        //public Ticket()
        //{

        //}

        //public Ticket(string id_Ticket, string id_Carro, DateTime dataEntrada)
        //{
        //    Id_Ticket = id_Ticket;
        //    Id_Carro = id_Carro;
        //    DataEntrada = dataEntrada;
        //    DataSaida = null;
        //    Valor = 0.00;
        //}

    }
}
