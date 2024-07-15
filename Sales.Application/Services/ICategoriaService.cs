using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Application.Services;

public interface ICategoriaService
{
    Task Save(CategoriaCreationDto category);
    Task Update(CategoriaUpdateDto category);
    Task<CategoriaModel?> Get(int id);
    Task<List<Categoria>> GetAll();
    Task DeleteCategory(int id);
    Task<List<Categoria>> GeAllWithFilter();
}