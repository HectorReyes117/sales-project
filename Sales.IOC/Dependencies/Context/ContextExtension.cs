using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Infraestructure.Context;

namespace Sales.IOC.Dependencies.Context;

public static class ContextExtension
{
    public static void RegisterContext(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnectionString"); 
        
        if (string.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString), "ConnectionString not found");
        
        services.AddDbContext<SalesContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}