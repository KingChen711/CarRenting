using CarRenting.Models.Entities;

namespace CarRenting.DataAccess.Abstractions;

public interface ICarRepository : IGenericRepository<Car>
{
    Task<IEnumerable<Car>> GetAllCars(bool trackChanges);
}