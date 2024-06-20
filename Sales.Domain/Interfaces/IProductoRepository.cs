using Sales.Domain.Entities;
using Sales.Domain.Models;

namespace Sales.Domain.Interfaces;

public interface IProductoRepository : IRepository<Producto>
{
    Task<List<ProductModel>> GetAllProductsByCategory(string category);
    Task<ProductModel> GetProductById(int id);
    Task<List<ProductModel>> GetAllProducts();
    Task DeleteProduct(int id);
}