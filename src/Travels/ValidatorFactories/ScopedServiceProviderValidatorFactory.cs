﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Travels.Api.ValidatorFactories;

public class ScopedServiceProviderValidatorFactory : ValidatorFactoryBase
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates new instance of <see cref="ScopedServiceProviderValidatorFactory"/>.
    /// </summary>
    /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
    public ScopedServiceProviderValidatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    [DebuggerStepThrough]
    public override IValidator CreateInstance(Type validatorType)
    {
        try
        {
            return _serviceProvider.GetService(validatorType) as IValidator;
        }
        catch (InvalidOperationException)
        {
            using (_serviceProvider.CreateScope())
                return _serviceProvider.CreateScope().ServiceProvider.GetService(validatorType) as IValidator;
        }
    }
}
