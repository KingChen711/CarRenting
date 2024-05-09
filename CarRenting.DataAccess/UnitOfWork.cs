using CarRenting.DataAccess.Abstractions;

namespace CarRenting.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentingDbContext _context;
        private readonly Lazy<ICarRepository> _carRepository;

        public UnitOfWork(CarRentingDbContext context)
        {
            _context = context;
            _carRepository = new Lazy<ICarRepository>(() => new
                CarRepository(context));
        }

        public ICarRepository Car => _carRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}