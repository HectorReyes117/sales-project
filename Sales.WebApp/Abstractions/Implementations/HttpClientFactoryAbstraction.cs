using Sales.WebApp.Configurations;

namespace Sales.WebApp.Abstractions.Implementations;

public class HttpClientFactoryAbstraction : IHttpClientFactoryAbstraction
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Settings? _settings;

    public HttpClientFactoryAbstraction(
        IHttpClientFactory httpClientFactory, 
        IConfiguration configuration
        )
    {
        _httpClientFactory = httpClientFactory;
        _settings = configuration.GetSection("Settings").Get<Settings>();
    }

    public HttpClient CreateClient()
    {
        string? httpClientName = _settings?.HttpClientName;
        ArgumentException.ThrowIfNullOrEmpty(httpClientName);
        
        HttpClient client = _httpClientFactory.CreateClient(_settings!.HttpClientName ?? "");
        return client;
    }

    public HttpClient CreateClient(string name)
    {
        HttpClient client = _httpClientFactory.CreateClient(name);
        return client;
    }
}