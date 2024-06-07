using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Repositories;

namespace Sales.IOC.Dependencies.Repositories;

public static class ProductRepositoryExtension
{
    public static IServiceCollection RegisterProductRepository(this IServiceCollection services)
    {
        services.AddScoped<IProductoRepository, ProductoRepository>();
        return services;
    }
}