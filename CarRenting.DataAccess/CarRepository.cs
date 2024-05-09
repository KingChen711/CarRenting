using CarRenting.DataAccess.Abstractions;
using CarRenting.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRenting.DataAccess;

public class CarRepository : GenericRepository<Car>, ICarRepository
{
    public CarRepository(CarRentingDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> GetAllCars(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }
}