
using System.Collections.Generic;

namespace Projeto.Entities
{
    public class Patio
    {
        public int Id_Patio { get; set; }
        public int Capacidade_Total { get; set; }
        public int Vagas_Ocupadas { get; set; }
        public List<Ticket> Tickets { get; set; }

        //public Patio()
        //{
        //    Id_Patio = 1;
        //    Capacidade_Total = 50;
        //    Vagas_Ocupadas = 0;

        //}
    }
}
