using Sales.WebApp.Configurations;

namespace Sales.WebApp.Extensions;

public static class ConfigureHttpClientExtension
{
    public static IServiceCollection ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        Settings? settings = configuration.GetSection("Settings").Get<Settings>();
        
        services.AddHttpClient(
            settings!.HttpClientName, 
            client =>
        {
            // Set the base address of the named client.
            client.BaseAddress = new Uri(settings!.ApiUrl);

            // Add a user-agent default request header.
            client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
        });
        
        return services;
    }
}