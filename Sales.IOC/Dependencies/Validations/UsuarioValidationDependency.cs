using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Validations.UsuarioValidations;
using Sales.Application.Validations.VentaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class UsuarioValidationDependency
{
    public static IServiceCollection RegisterUsuarioValidations(this IServiceCollection services)
    { 
        services.AddValidatorsFromAssemblyContaining<UsuarioCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UsuarioUpdateDtoValidation>();
        return services;
    }
}