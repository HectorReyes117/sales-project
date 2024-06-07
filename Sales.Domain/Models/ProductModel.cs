namespace Sales.Domain.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string? CodigoBarra { get; set; }
    public string? Marca { get; set; }
    public int? Stock { get; set; }
    public string NombreCategoria { get; set; } = string.Empty;
}