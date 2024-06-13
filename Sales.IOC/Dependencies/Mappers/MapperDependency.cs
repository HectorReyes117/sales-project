using Microsoft.Extensions.DependencyInjection;

namespace Sales.IOC.Dependencies.Mappers;

public static class MapperDependency
{
    public static void RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}