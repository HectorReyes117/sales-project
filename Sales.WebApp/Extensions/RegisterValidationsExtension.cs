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
        services.AddValidatorsFromAssemblyContaining<CategoriaCreationViewModelValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoriaUpdateViewModelValidator>();
        services.AddValidatorsFromAssemblyContaining<DetalleVentaCreationViewModelValidation>();
        services.AddValidatorsFromAssemblyContaining<DetalleVentaUpdateViewModelValidation>();
        services.AddValidatorsFromAssemblyContaining<ProductoCreationViewModelValidation>();
        services.AddValidatorsFromAssemblyContaining<ProductoUpdateViewModelValidation>();
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<TipoDocumentoVentaUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UsuarioCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<UsuarioUpdateDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<VentaCreationDtoValidation>();
        services.AddValidatorsFromAssemblyContaining<VentaUpdateDtoValidation>();
        return services;
    }
}