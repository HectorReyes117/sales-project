using Sales.WebApp.Models.Producto;

namespace Sales.WebApp.Request;

public interface IProductoRequests
{
    Task<HttpResponseMessage> Save(ProductoCreationViewModel usuario);
    Task<HttpResponseMessage> Update(ProductoUpdateViewModel usuario);
    Task<ProductoModel?> Get(int id);
    Task<List<ProductoModel>> GetAll();
    Task<HttpResponseMessage> DeleteProduct(int id);
}