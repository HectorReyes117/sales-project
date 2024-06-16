using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Services;
using Sales.Application.Services.Implementations;

namespace Sales.IOC.Dependencies.Services;

public static class BaseApplicationServiceRegister
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IDetalleVentaService, DetalleVentaService>();
        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<ITipoDocumentoVentaService,TipoDocumentoVentaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IVentaService, VentaService>();
        return services;
    }
}