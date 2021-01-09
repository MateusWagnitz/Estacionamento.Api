using System;
using System.Collections.Generic;


namespace Projeto.Entities
{
    public class Carro
    {
        public string Placa { get; private set; }
        public string Id_Dono { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime HoraEntrada { get; set; }
        public List<Ticket> Tickets { get; set; }


        //public List<Carro> ListaCarros = new List<Carro>();

        //public Carro() { }



        //public Carro(string placa, string id_Dono, string marca, string modelo)
        //{
        //    Placa = placa;
        //    Id_Dono = id_Dono;
        //    Marca = marca;
        //    Modelo = modelo;
        //}
    }
}


