using Sales.WebApp.Abstractions;
using Sales.WebApp.Abstractions.Implementations;

namespace Sales.WebApp.Extensions;

public static class RegisterHttpClientFactoryExtension
{
    public static IServiceCollection RegisterHttpClientFactory(this IServiceCollection services)
    {
        services.AddScoped<IHttpClientFactoryAbstraction, HttpClientFactoryAbstraction>();
        return services;
    }
}