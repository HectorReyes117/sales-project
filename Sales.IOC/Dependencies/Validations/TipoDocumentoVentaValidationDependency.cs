using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Validations.TipoDocumentoVentaValidations;
using Sales.Application.Validations.VentaValidations;

namespace Sales.IOC.Dependencies.Validations;

public static class TipoDocumentoVentaValidationDependency
{
    public static IServiceCollection RegisterTipoDocumentoVentaValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaUpdateDtoValidation>();
        return services;
    }
}