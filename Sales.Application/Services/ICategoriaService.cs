using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface ICategoriaService
{
    Task Save(CategoriaCreationDto category);
    Task Update(CategoriaUpdateDto category);
    Task<Categoria?> Get(int id);
    Task<List<Categoria>> GetAll();
}