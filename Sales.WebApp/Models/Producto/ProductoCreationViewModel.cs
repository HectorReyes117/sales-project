namespace Sales.WebApp.Models.Producto;

public class ProductoCreationViewModel
{
    public string? CodigoBarra { get; set; }
    public string? Marca { get; set; }
    public string? Descripcion { get; set; }
    public int? IdCategoria { get; set; }
    public int? Stock { get; set; }
    public string? UrlImagen { get; set; }
    public string? NombreImagen { get; set; }
    public decimal? Precio { get; set; }
    public bool? EsActivo { get; set; }
}