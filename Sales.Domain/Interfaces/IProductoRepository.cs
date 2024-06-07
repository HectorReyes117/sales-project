using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface IProductoRepository : IRepository<Producto>
{
    Task<List<ProductModel>> GetAllProductsByCategory(string category);
}