using Sales.Domain.Core;

namespace Sales.Domain.Entities;

public sealed class Categoria : BaseEntity
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public ICollection<Producto> Productos { get; set; }
}
