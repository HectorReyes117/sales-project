using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Services;
using Sales.Application.Services.Implementations;

namespace Sales.IOC.Dependencies.Services;

public static class CategoriaServiceDependency
{
    public static void RegisterCategoriaService(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaService, CategoriaService>();
    }
}