using FluentValidation;
using Sales.WebApp.Validations.CategoriaValidations;
using Sales.WebApp.Validations.DetalleVentaValidations;
using Sales.WebApp.Validations.ProductoValidations;
using Sales.WebApp.Validations.TipoDocumentoVentaValidations;
using Sales.WebApp.Validations.UsuarioValidations;
using Sales.WebApp.Validations.VentaValidations;

namespace Sales.WebApp.Extensions;

public static class RegisterValidationsExtension
{
    public static IServiceCollection RegisterValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CategoriaCreationDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoriaUpdateDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<DetalleVentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<DetalleVentaUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ProductoCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<ProductoUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UsuarioCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UsuarioUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<VentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<VentaUpdateDtoValidation>();
        return services;
    }
}