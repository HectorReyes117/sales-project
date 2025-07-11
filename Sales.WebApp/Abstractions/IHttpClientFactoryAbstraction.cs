namespace Sales.WebApp.Abstractions;

public interface IHttpClientFactoryAbstraction
{
    HttpClient CreateClient();
    HttpClient CreateClient(string name);
}