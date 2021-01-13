using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingModel
{

    [Table("Carros")]
    public class Carro
    {
        public int CaroId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public Usuario Usuario { get; set; }
    }
}
