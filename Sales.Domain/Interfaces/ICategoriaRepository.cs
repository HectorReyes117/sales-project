using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task DeleteCategory(int id);
    Task<CategoriaModel?> GetCategoryById(int id);
    Task<List<Categoria>> GeAllWithFilter();
}