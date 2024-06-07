using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.IOC.Dependencies.Context;
using Sales.IOC.Dependencies.Repositories;

namespace Sales.IOC.Dependencies;

public static class BaseRegisterServices
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // register context database
        services.RegisterContext(configuration);
        
        // register repositories
        services
            .RegisterProductRepository()
            .RegisterVentaRepository();
        
    }
}