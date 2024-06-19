using Sales.WebApp.Models.Categories;

namespace Sales.WebApp.Request;

public interface ICategoriaRequests
{
    Task<HttpResponseMessage> Save(CategoriaCreationViewModel usuario);
    Task<HttpResponseMessage> Update(CategoriaUpdateViewModel usuario);
    Task<CategoriaModel?> Get(int id);
    Task<List<CategoriaModel>> GetAll();
    Task<HttpResponseMessage> DeleteCategory(int id);
}