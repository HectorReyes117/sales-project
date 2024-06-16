using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Validations.ProductoValidations;
using Sales.Application.Validations.VentaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class ProductValidationDependency
{
    public static IServiceCollection RegisterProductValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProductoCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ProductoUpdateDtoValidation>();
        return services;
    }
}