using Sales.WebApp.Models.Categories;

namespace Sales.WebApp.Models.Producto;

public class ProductoUpdateViewModel
{
    public int Id { get; set; }
    public string? CodigoBarra { get; set; }
    public string? Marca { get; set; }
    public string? Descripcion { get; set; }
    public int? IdCategoria { get; set; }
    public int? Stock { get; set; }
    public string? UrlImagen { get; set; }
    public string? NombreImagen { get; set; }
    public decimal? Precio { get; set; }
    public bool EsActivo { get; set; }
    public List<CategoriaModel> Categories { get; set; }
}