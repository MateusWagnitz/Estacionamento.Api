using System.Collections.Generic;


namespace Projeto.Entities
{
    class Carro
    {
        public string Id_Placa { get; private set; }
        public string Id_Dono { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }


        public List<Carro> ListaCarros = new List<Carro>();

        public Carro() { }



        public Carro(string id_Placa, string id_Dono, string marca, string modelo)
        {
            Id_Placa = id_Placa;
            Id_Dono = id_Dono;
            Marca = marca;
            Modelo = modelo;
        }
    }


}

