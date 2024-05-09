using CarRenting.Models.Entities;

namespace CarRenting.BusinessLogic.Abstractions;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAllCars(bool trackChanges);
}