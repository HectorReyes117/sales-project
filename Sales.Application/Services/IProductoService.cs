using Sales.Application.Dtos.ProductoDto;
using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Application.Services;

public interface IProductoService
{
    Task Save(ProductoCreationDto producto);
    Task Update(ProductoUpdateDto producto);
    Task<ProductModel?> Get(int id);
    Task<List<ProductModel>> GetAll();
    Task DeleteProduct(int id);
}