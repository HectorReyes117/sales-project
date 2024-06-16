using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<List<UsuarioModel>> GetAllUsers();
}