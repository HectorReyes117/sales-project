using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application.Middlewares;

namespace Sales.IOC.Dependencies.Middlewares;

public static class MiddlewareDependency
{
    public static void RegisterMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<FluentValidationMiddleware>();
    }
}