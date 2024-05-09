using CarRenting.BusinessLogic.Abstractions;
using CarRenting.DataAccess.Abstractions;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CarRenting.BusinessLogic;

public class ServiceFactory : IServiceFactory
{
    private readonly Lazy<IEmailSender> _emailService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        IFluentEmail fluentEmail
    )
    {
        _emailService = new Lazy<IEmailSender>(() => new EmailService(fluentEmail));
    }

    public IEmailSender Email => _emailService.Value;
}