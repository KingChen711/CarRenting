using Microsoft.AspNetCore.Identity.UI.Services;

namespace CarRenting.BusinessLogic.Abstractions;

public interface IServiceFactory
{
    IEmailSender Email { get; }
    ICarService Car { get; }
}