namespace Sales.Domain.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public string? CodigoBarra { get; set; }
    public string? Marca { get; set; }
    public int? Stock { get; set; }
    public string NombreCategoria { get; set; } = string.Empty;
    public int? IdCategoria { get; set; }
    public bool? EsActivo { get; set; }
    public decimal? Precio { get; set; }
    public string? UrlImagen { get; set; }
    public bool Eliminado { get; set; }
}