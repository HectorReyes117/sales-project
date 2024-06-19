namespace Sales.WebApp.Models.Categories;

public class CategoriaModel
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public bool Eliminado { get; set; }
}