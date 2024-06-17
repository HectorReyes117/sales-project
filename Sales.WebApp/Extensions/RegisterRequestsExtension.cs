using Sales.WebApp.Request;
using Sales.WebApp.Request.Implementations;

namespace Sales.WebApp.Extensions;

public static class RegisterRequestsExtension
{
    public static IServiceCollection RegisterRequest(this IServiceCollection services)
    {
        services.AddScoped<IUsuariosRequests, UsuariosRequests>();
        return services;
    }
}