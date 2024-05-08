using CarRenting.BusinessLogic.Abstractions;
using CarRenting.DataAccess.Abstractions;
using CarRenting.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRenting.BusinessLogic;

public class ServiceFactory : IServiceFactory
{
    // private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        UserManager<User> userManager
    )
    {
        // _companyService = new Lazy<ICompanyService>(() => new CompanyService(unitOfWork));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager));
    }

    // public ICompanyService Company => _companyService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}