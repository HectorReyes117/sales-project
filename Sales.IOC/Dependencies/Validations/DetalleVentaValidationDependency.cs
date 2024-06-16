using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Validations.DetalleVentaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class DetalleVentaValidationDependency
{
    public static IServiceCollection RegisterDetalleVentaValidations(this IServiceCollection services)
    { 
        services.AddValidatorsFromAssemblyContaining<DetalleVentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<DetalleVentaUpdateDtoValidation>();
        return services;
    }
}