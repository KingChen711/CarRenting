namespace CarRenting.BusinessLogic.Abstractions;

public interface IServiceFactory
{
    IAuthenticationService AuthenticationService { get; }
}