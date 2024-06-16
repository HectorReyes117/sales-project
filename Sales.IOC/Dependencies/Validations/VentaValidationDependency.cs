using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Validations.VentaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class VentaValidationDependency
{
    public static IServiceCollection RegisterVentaValidations(this IServiceCollection services)
    { 
        services.AddValidatorsFromAssemblyContaining<VentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<VentaUpdateDtoValidation>();
        return services;
    }
}