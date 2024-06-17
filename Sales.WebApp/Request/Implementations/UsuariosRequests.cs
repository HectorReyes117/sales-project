using System.Reflection.Metadata.Ecma335;
using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;
using Sales.WebApp.Abstractions;

namespace Sales.WebApp.Request.Implementations;

public class UsuariosRequests : IUsuariosRequests
{
    private readonly IHttpClientFactoryAbstraction _factoryAbstraction;

    public UsuariosRequests(IHttpClientFactoryAbstraction factoryAbstraction)
    {
        _factoryAbstraction = factoryAbstraction;
    }

    public async Task<HttpResponseMessage> Save(UsuarioCreationDto usuario)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PostAsJsonAsync("usuario", usuario);
        return response;
    }

    public async Task<HttpResponseMessage> Update(UsuarioUpdateDto usuario)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.PutAsJsonAsync("usuario", usuario);
        return response;
    }

    public async Task<Usuario?> Get(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var user = await client.GetFromJsonAsync<Usuario>($"usuario/{id}");
        return user;
    }

    public async Task<List<UsuarioModel>> GetAll()
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        var users = await client.GetFromJsonAsync<List<UsuarioModel>>("usuario");
        return users!;
    }

    public async  Task<HttpResponseMessage> DeleteUser(int id)
    {
        using HttpClient client = _factoryAbstraction.CreateClient();
        HttpResponseMessage response = await client.DeleteAsync($"usuario/{id}");
        return response;
    }
}