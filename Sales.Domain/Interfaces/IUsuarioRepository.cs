using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<List<UsuarioModel>> GetAllUsers();
    Task DeleteUser(int id);
    Task<UsuarioModel?> GetByUserId(int id);
}