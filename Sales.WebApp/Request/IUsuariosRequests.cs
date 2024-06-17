using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.WebApp.Request;

public interface IUsuariosRequests
{
    Task<HttpResponseMessage> Save(UsuarioCreationDto usuario);
    Task<HttpResponseMessage> Update(UsuarioUpdateDto usuario);
    Task<Usuario?> Get(int id);
    Task<List<UsuarioModel>> GetAll();
    Task<HttpResponseMessage> DeleteUser(int id);
}