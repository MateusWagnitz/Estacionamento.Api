using ParkingModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingContext
{
    public interface IRepositoryCarro
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Carro>> GetAllCars();
        Task<Carro> GetCarById(string placa);
        Task<bool> AddCar(Carro model);

    }
}
