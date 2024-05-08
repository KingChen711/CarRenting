using CarRenting.DataAccess.Abstractions;

namespace CarRenting.DataAccess
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentingDbContext _context;
        //private readonly Lazy<ICompanyRepository> _companyRepository;

        public UnitOfWork(CarRentingDbContext context)
        {
            _context = context;
            //_companyRepository = new Lazy<ICompanyRepository>(() => new
            //    CompanyRepository(context));
        }

        //public ICompanyRepository Company => _companyRepository.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
