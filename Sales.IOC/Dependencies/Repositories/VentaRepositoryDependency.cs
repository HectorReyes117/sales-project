using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Repositories;

namespace Sales.IOC.Dependencies.Repositories;

public static class VentaRepositoryDependency
{
    public static IServiceCollection RegisterVentaRepository(this IServiceCollection services)
    {
        services.AddScoped<IVentaRepository, VentaRepository>();
        return services;
    }
}