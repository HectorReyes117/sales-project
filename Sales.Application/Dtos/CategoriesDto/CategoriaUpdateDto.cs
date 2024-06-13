namespace Sales.Application.Dtos.CategoriesDto;

public class CategoriaUpdateDto
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
}