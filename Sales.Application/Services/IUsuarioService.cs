using Sales.Application.Dtos.UsuarioDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Application.Services;

public interface IUsuarioService
{
    Task Save(UsuarioCreationDto usuario);
    Task Update(UsuarioUpdateDto usuario);
    Task<Usuario?> Get(int id);
    Task<List<UsuarioModel>> GetAll();
    Task DeleteUser(int id);
}