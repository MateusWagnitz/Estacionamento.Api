using ParkingModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingContext
{
    public interface IRepositoryPatio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<List<Patio>> GetAllCars();
        Task<Patio> GetCarById(string placa);

    }
}
