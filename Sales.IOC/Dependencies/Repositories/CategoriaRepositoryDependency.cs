using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Interfaces;
using Sales.Infraestructure.Repositories;

namespace Sales.IOC.Dependencies.Repositories;

public static class CategoriaRepositoryDependency
{
    public static void RegisterCategoriaRepository(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
    }
}