using CarRenting.Models.Dtos.User;
using Microsoft.AspNetCore.Identity;

namespace CarRenting.BusinessLogic.Abstractions;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistration);
    Task<bool> ValidateUser(UserAuthenticationDto userAuth);
}
