using Sales.WebApp.Models.Categories;
using Sales.WebApp.Abstractions;
using Sales.WebApp.Models.Categories;

namespace Sales.WebApp.Request.Implementations;

public class CategoriaRequests : ICategoriaRequests
{
    private readonly IHttpClientFactoryAbstraction _factoryAbstraction;

    public CategoriaRequests(IHttpClientFactoryAbstraction factoryAbstraction)
    {
        _factoryAbstraction = factoryAbstraction;
    }

    public async Task<HttpResponseMessage> Save(CategoriaCreationViewModel category)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync("categoria", category);
        return response;
    }

    public async Task<HttpResponseMessage> Update(CategoriaUpdateViewModel category)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync("categoria", category);
        return response;
    }

    public async Task<CategoriaModel?> Get(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var category = await client.GetFromJsonAsync<CategoriaModel>($"categoria/{id}");
        return category;
    }

    public async Task<List<CategoriaModel>> GetAll()
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var categories = await client.GetFromJsonAsync<List<CategoriaModel>>("categoria");
        return categories!;
    }

    public async Task<HttpResponseMessage> DeleteCategory(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"categoria/{id}");
        return response;
    }
}