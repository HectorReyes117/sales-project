using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.IOC.Dependencies.Context;
using Sales.IOC.Dependencies.Mappers;
using Sales.IOC.Dependencies.Repositories;
using Sales.IOC.Dependencies.Services;
using Sales.IOC.Dependencies.Validations;

namespace Sales.IOC.Dependencies;

public static class BaseRegisterServices
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // register context database
        services.RegisterContext(configuration);
        
        // register repositories
        services
            .RegisterRepositories();
        
        //register services
        services
            .RegisterApplicationServices();
        
        // register mappers
        services.RegisterMapper();
        
        //register validations
        services
            .RegisterCategoriaValidations()
            .RegisterVentaValidations()
            .RegisterDetalleVentaValidations()
            .RegisterUsuarioValidations()
            .RegisterTipoDocumentoVentaValidations()
            .RegisterProductValidations();
    }
}