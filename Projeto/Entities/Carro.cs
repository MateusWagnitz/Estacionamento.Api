using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingModel
{

    public class Carro
    {
        public int CarroId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
