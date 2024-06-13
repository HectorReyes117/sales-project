using System.Linq.Expressions;
using Sales.Application.Dtos.CategoriesDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface ICategoriaService
{
    Task Save(CategoriaCreationDto category);
    Task Save(List<CategoriaCreationDto> categories );
    Task Update(CategoriaUpdateDto category);
    Task Update(List<CategoriaUpdateDto>  categories);
    Task<Categoria?> Get(int id);
    Task<List<Categoria>> GetAll();
}