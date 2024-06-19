using Sales.WebApp.Abstractions;
using Sales.WebApp.Models.Producto;

namespace Sales.WebApp.Request.Implementations;

public class ProductoRequests : IProductoRequests
{
    private readonly IHttpClientFactoryAbstraction _factoryAbstraction;

    public ProductoRequests(IHttpClientFactoryAbstraction factoryAbstraction)
    {
        _factoryAbstraction = factoryAbstraction;
    }
    
    public async Task<HttpResponseMessage> Save(ProductoCreationViewModel product)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync("producto", product);
        return response;
    }

    public async Task<HttpResponseMessage> Update(ProductoUpdateViewModel product)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync("producto", product);
        return response;
    }

    public async Task<ProductoModel?> Get(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var user = await client.GetFromJsonAsync<ProductoModel>($"producto/{id}");
        return user;
    }

    public async Task<List<ProductoModel>> GetAll()
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var users = await client.GetFromJsonAsync<List<ProductoModel>>("producto");
        return users!;
    }

    public async Task<HttpResponseMessage> DeleteProduct(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"producto/{id}");
        return response;
    }
}