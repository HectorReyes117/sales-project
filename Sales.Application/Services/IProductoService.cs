using Sales.Application.Dtos.ProductoDto;
using Sales.Domain.Entities;

namespace Sales.Application.Services;

public interface IProductoService
{
    Task Save(ProductoCreationDto producto);
    Task Update(ProductoUpdateDto producto);
    Task<Producto?> Get(int id);
    Task<List<Producto>> GetAll();
}