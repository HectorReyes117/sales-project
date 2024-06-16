using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Repositories;

namespace Sales.IOC.Dependencies.Repositories;

public static class BaseRegisterRepositoriesDependency
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IVentaRepository, VentaRepository>();
        services.AddScoped<ITipoDocumentoVentaRepository, TipoDocumentoVentaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        return services;
    }
}