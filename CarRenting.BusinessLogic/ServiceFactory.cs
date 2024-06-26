﻿using CarRenting.BusinessLogic.Abstractions;
using CarRenting.DataAccess.Abstractions;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CarRenting.BusinessLogic;

public class ServiceFactory : IServiceFactory
{
    private readonly Lazy<IEmailSender> _emailService;
    private readonly Lazy<ICarService> _carService;

    public ServiceFactory(
        IUnitOfWork unitOfWork,
        IFluentEmail fluentEmail
    )
    {
        _emailService = new Lazy<IEmailSender>(() => new EmailService(fluentEmail));
        _carService = new Lazy<ICarService>(() => new CarService(unitOfWork));
    }

    public IEmailSender Email => _emailService.Value;
    public ICarService Car => _carService.Value;
}