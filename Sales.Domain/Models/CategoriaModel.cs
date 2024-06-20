namespace Sales.Domain.Models;

public class CategoriaModel
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool EsActivo { get; set; }
    public bool Eliminado { get; set; }
}