namespace Sales.WebApp.Abstractions;

public interface IHttpClientFactoryAbstraction
{
    HttpClient CreateClient();
}