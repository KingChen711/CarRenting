using CarRenting.BusinessLogic.Abstractions;
using CarRenting.DataAccess.Abstractions;
using CarRenting.Models.Entities;

namespace CarRenting.BusinessLogic;

public class CarService : ICarService
{
    private readonly IUnitOfWork _unitOfWork;

    public CarService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Car>> GetAllCars(bool trackChanges)
    {
        return await _unitOfWork.Car.GetAllCars(trackChanges);
    }
}